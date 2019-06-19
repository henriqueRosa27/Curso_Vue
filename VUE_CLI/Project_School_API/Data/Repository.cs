using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_School_API.Models;

namespace Project_School_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync<T>()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //Aluno
        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor) 
            {
                query = query.Include(a => a.Professor);
            }

            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAlunosByProfessorAsync(int idProfessor, bool includeProfessor )
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor) 
            {
                query = query.Include(a => a.Professor);
            }

            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.id)
                    .Where(a => a.idProfessor == idProfessor);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoByIdAsync(int id, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor) 
            {
                query = query.Include(a => a.Professor);
            }

            query = query
                    .AsNoTracking()
                    .Where(a => a.id == id);

            return await query.FirstOrDefaultAsync();
        }

        //Professor
        public async Task<Professor[]> GetProfessorAsync(bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno) 
            {
                query = query.Include(a => a.alunos);
            }

            query = query
                    .AsNoTracking()
                    .OrderBy(p => p.id);
                    

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorById(int id, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno) 
            {
                query = query.Include(a => a.alunos);
            }

            query = query
                    .AsNoTracking()
                    .Where(p => p.id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}