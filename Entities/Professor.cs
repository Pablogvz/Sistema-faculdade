using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapiens.Shared.Entities
{
    // Professor herda de Funcionario
    internal class Professor : Funcionario
    {
        // Construtor que usa o construtor da classe base
        public Professor(string nome, Curso curso)
            : base(nome, curso)
        {
        }

        // Outras propriedades ou métodos específicos da classe Professor podem ser adicionados aqui
    }
}
