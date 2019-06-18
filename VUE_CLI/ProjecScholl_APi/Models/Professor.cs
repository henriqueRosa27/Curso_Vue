using System.Collections.Generic;

namespace ProjecScholl_APi.Models
{
    public class Professor
    {
        public int id { get; set; }

        public string nome { get; set; }

        public List<Aluno> alunos { get; set; }
    }
}