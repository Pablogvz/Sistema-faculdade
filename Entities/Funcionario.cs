using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapiens.Shared.Entities
{
    public class Funcionario
    {
        [StringLength(100)]
        public string Nome { get; set; }

        public Curso Curso { get; set; }

        public Funcionario(string nome, Curso curso)
        {
            Nome = nome;
            Curso = curso;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
