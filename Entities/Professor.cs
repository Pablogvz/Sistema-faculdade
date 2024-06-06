using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapiens.Shared.Entities
{
    // Professor herda de Pessoa
    public class Professor : Pessoa
    {

        public string? Formacao { get; set; }
        public bool Coordenador { get; set; }
        public int CargaHoraria { get; set; }

        public List<Disciplina>? Disciplinas { get; } = new();
    }
}
