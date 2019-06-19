using System.Collections.Generic;

namespace Project_School_API.Models
{
    public class Professor
    {
        public int id { get; set; }

        public string nome { get; set; }

        public List<Aluno> alunos { get; set; }
    }
}