using System.ComponentModel.DataAnnotations.Schema;

namespace Project_School_API.Models
{
    public class Aluno
    {
        public int id { get; set; }
        
        public string nome { get; set; }

        public string sobrenome { get; set; }

        public string dataNasc { get; set; }

        public int idProfessor { get; set; }

        [ForeignKey("idProfessor")]
        public Professor Professor { get; set; }
    }
}