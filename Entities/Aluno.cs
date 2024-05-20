using Sapiens.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sapiens.Shared.Entities
{
    public class Aluno
    {
        [StringLength(100)]
        public string Nome { get; set; }

        public int Ra { get; set; }

        public string Periodo { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telefone { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Endereco { get; set; }

        // Associação com Curso
        public Curso Curso { get; set; }

        public Aluno(string nome, int ra, string periodo, string email, string telefone, DateTime dataDeNascimento, string endereco, Curso curso)
        {
            Nome = nome;
            Ra = ra;
            Periodo = periodo;
            Email = email;
            Telefone = telefone;
            DataDeNascimento = dataDeNascimento;
            Endereco = endereco;
            Curso = curso;
        }

        public override string ToString()
        {
            return $"{Nome} (RA: {Ra}, Período: {Periodo}, Email: {Email}, Telefone: {Telefone}, Data de Nascimento: {DataDeNascimento.ToShortDateString()}, Endereço: {Endereco}, Curso: {Curso.Nome})";
        }
    }
}