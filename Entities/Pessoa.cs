using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapiens.Shared.Enums;

namespace Sapiens.Shared.Entities
{
    public class Pessoa
    {
        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public string? Cpf { get; set; }

        private string? email { get; set; }

        private string? celular { get; set; }

        public TipoSexo Sexo { get; set; }

        public string? Cep { get; set; }

    }
}
