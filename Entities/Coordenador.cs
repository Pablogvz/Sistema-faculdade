using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapiens.Shared.Entities
{
    public class Coordenador : Funcionario
    {
        // Construtor que usa o construtor da classe base
        public Coordenador(string nome, Curso curso)
            : base(nome, curso)
        {
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
