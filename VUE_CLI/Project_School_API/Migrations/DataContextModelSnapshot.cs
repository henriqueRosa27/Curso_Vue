﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_School_API.Data;

namespace Project_School_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Project_School_API.Models.Aluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("dataNasc");

                    b.Property<int>("idProfessor");

                    b.Property<string>("nome");

                    b.Property<string>("sobrenome");

                    b.HasKey("id");

                    b.HasIndex("idProfessor");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            dataNasc = "01/01/2000",
                            idProfessor = 1,
                            nome = "Maria",
                            sobrenome = "José"
                        },
                        new
                        {
                            id = 2,
                            dataNasc = "20/01/1990",
                            idProfessor = 2,
                            nome = "João",
                            sobrenome = "Paulo"
                        },
                        new
                        {
                            id = 3,
                            dataNasc = "25/06/1981",
                            idProfessor = 3,
                            nome = "Alex",
                            sobrenome = "Ferraz"
                        });
                });

            modelBuilder.Entity("Project_School_API.Models.Professor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nome");

                    b.HasKey("id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            id = 1,
                            nome = "Henrique"
                        },
                        new
                        {
                            id = 2,
                            nome = "Paula"
                        },
                        new
                        {
                            id = 3,
                            nome = "Luna"
                        });
                });

            modelBuilder.Entity("Project_School_API.Models.Aluno", b =>
                {
                    b.HasOne("Project_School_API.Models.Professor", "Professor")
                        .WithMany("alunos")
                        .HasForeignKey("idProfessor")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
