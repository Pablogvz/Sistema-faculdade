using Sapiens.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sapiens.Shared.Entities
{
    public class Aluno : Pessoa
    {
        public int Matricula { get; set; }


        public Curso? Curso { get; set; }
    }
}