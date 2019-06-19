using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project_School_API.Models;

namespace Project_School_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
                .HasData(
                    new List<Professor>
                    {
                        new Professor(){
                            id = 1,
                            nome = "Henrique"
                        },
                        new Professor(){
                            id = 2,
                            nome = "Paula"
                        },
                        new Professor(){
                            id = 3,
                            nome = "Luna"
                        }
                    }
                );

            builder.Entity<Aluno>()
                .HasData(
                    new List<Aluno>
                    {
                        new Aluno(){
                            id = 1,
                            nome = "Maria",
                            sobrenome = "José",
                            dataNasc = "01/01/2000",
                            idProfessor = 1
                        },
                        new Aluno(){
                            id = 2,
                            nome = "João",
                            sobrenome = "Paulo",
                            dataNasc = "20/01/1990",
                            idProfessor = 2
                        },
                        new Aluno(){
                            id = 3,
                            nome = "Alex",
                            sobrenome = "Ferraz",
                            dataNasc = "25/06/1981",
                            idProfessor = 3
                        }
                    }
                );
        }
    }
}