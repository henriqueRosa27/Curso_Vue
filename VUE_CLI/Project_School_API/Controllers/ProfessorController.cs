using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_School_API.Data;
using Project_School_API.Models;

namespace Project_School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public IRepository _repo { get; }
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult>  Get()
        {
             try
            {
                var results = await _repo.GetProfessorAsync(true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dado Fallhou");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             try
            {
                var results = await _repo.GetProfessorById(id, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dado Fallhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync<Professor>())
                {
                    return Created($"/api/aluno/{model.id}", model);
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dado Fallhou");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Professor model)
        {
             try
            {
                var professor = await _repo.GetProfessorById(id, true);

                if(professor == null) return NotFound();

                _repo.Update(model);
                
                if(await _repo.SaveChangesAsync<Professor>())
                {
                    professor = await _repo.GetProfessorById(id, true);
                    return Created($"api/professor/{model.id}", professor);
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dado Fallhou");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             try
            {
                var professor = await _repo.GetProfessorById(id, true);

                if(professor == null) return NotFound();

                _repo.Delete(professor);

                if(await _repo.SaveChangesAsync<Professor>())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dado Fallhou");
            }

            return BadRequest();
        }
    }
}