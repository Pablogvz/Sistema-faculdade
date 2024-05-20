using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapiens.Shared.Entities
{
    public class Coordenador : Professor
    {
        public decimal Gratificacao { get; set; }
    }
}
