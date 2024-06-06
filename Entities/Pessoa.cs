using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapiens.Shared.Enums;

namespace Sapiens.Shared.Entities
{
    public class Pessoa : Entidade
    {
        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public string? Cpf { get; set; }

        public string? Email { get; set; }

        public string? Telefone { get; set; }

        public TipoSexo Sexo { get; set; }

        public string? Cep { get; set; }

    }
}
