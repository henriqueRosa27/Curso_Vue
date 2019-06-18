﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjecScholl_APi.Data;

namespace ProjecScholl_APi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("ProjecScholl_APi.Models.Aluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Professorid");

                    b.Property<string>("dataNasc");

                    b.Property<int>("idProfessor");

                    b.Property<string>("nome");

                    b.Property<string>("sobrenome");

                    b.HasKey("id");

                    b.HasIndex("Professorid");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("ProjecScholl_APi.Models.Professor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nome");

                    b.HasKey("id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("ProjecScholl_APi.Models.Aluno", b =>
                {
                    b.HasOne("ProjecScholl_APi.Models.Professor", "Professor")
                        .WithMany("alunos")
                        .HasForeignKey("Professorid");
                });
#pragma warning restore 612, 618
        }
    }
}
