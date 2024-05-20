using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapiens.Shared.Entities
{
    // Professor herda de Funcionario
    public class Professor : Funcionario
    {
        public int CargaHoraria { get; set; }

        public Curso? Curso { get; set; }
    }
}
