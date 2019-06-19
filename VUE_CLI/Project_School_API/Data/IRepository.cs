using System.Threading.Tasks;
using Project_School_API.Models;

namespace Project_School_API.Data
{
    public interface IRepository
    {
         //Geral
         void Add<T>( T entity) where T:class;
         void Update<T>(T entity) where T:class;
         void Delete<T>(T entity) where T:class;
         Task<bool> SaveChangesAsync<T>();

         //Aluno
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        Task<Aluno[]> GetAlunosByProfessorAsync(int idProfessor, bool includeProfessor);
        Task<Aluno> GetAlunoByIdAsync(int id, bool includeProfessor);

         //Professor
        Task<Professor[]> GetProfessorAsync(bool includeAluno);
        Task<Professor> GetProfessorById(int id, bool includeAluno);
    }
}