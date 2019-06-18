using Microsoft.EntityFrameworkCore;
using ProjecScholl_APi.Models;

namespace ProjecScholl_APi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set;}
        public DbSet<Professor> Professor { get; set;}
    }
}