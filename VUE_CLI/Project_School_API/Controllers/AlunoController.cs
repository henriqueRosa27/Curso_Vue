using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_School_API.Data;
using Project_School_API.Models;

namespace Project_School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        public IRepository _repo { get; }
        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllAlunosAsync(true);

                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dado Fallhou");
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _repo.GetAlunoByIdAsync(id, true);

                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dado Fallhou");
            }
        }
        
        [HttpGet("ByProfessor/{id}")]
        public async Task<ActionResult> GetByProfessor(int id)
        {
            try
            {
                var result = await _repo.GetAlunosByProfessorAsync(id, true);

                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dado Fallhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync<Aluno>())
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
        public async Task<IActionResult> Put(int id, Aluno model)
        {
             try
            {
                var aluno = await _repo.GetAlunoByIdAsync(id, false);

                if(aluno == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync<Aluno>())
                {
                    aluno = await _repo.GetAlunoByIdAsync(id, false);
                    return Created($"/api/aluno/{model.id}", model);
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
                var aluno = await _repo.GetAlunoByIdAsync(id, false);

                if(aluno == null) return NotFound();

                _repo.Delete(aluno);
                if(await _repo.SaveChangesAsync<Aluno>())
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