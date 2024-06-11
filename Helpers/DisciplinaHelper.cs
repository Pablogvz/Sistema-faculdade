using Microsoft.EntityFrameworkCore;
using Sapiens.Shared.Entities;
using Sapiens.Shared.Enums;
using System;
using System.Linq;

namespace Sapiens.Shared.Helpers
{
    public static partial class ConsoleHelper
    {
        public static void MenuDisciplina()
        {
            CriarTitulo("Sapiens - Cadastro de Disciplinas");
            var opcao = "";
            Console.WriteLine(" [1] Listar");
            Console.WriteLine(" [2] Consultar");
            Console.WriteLine(" [3] Adicionar");
            Console.WriteLine(" [4] Remover");
            Console.WriteLine("\n [9] Voltar");
            Console.WriteLine("-----------------------------------");
            Console.Write(" \nOpção: ");
            opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1": ListarDisciplinas(); break;
                case "2": ConsultarDisciplina(); break;
                case "3": AdicionarDisciplina(); break;
                case "4": RemoverDisciplina(); break;
                case "9": Menu(); break;
            }
        }

        public static void ListarRemocaoDisciplinas()
        {
            CriarTitulo("Sapiens - Lista de Disciplinas");
            var disciplinas = context.Disciplinas.Include(d => d.Professor).OrderBy(c => c.Nome).ToList();
            foreach (var disciplina in disciplinas)
            {
                var professorNome = disciplina.Professor?.Nome ?? "N/A";
                Console.WriteLine($"Id: {disciplina.Id}. Disciplina: {disciplina.Nome}. Professor(a): {professorNome}");
            }
            Console.WriteLine("-----------------------------------");
        }

        public static void ListarDisciplinas()
        {
            CriarTitulo("Sapiens - Lista de Disciplinas");
            var disciplinas = context.Disciplinas.Include(d => d.Professor).Include(d => d.Curso).OrderBy(c => c.Nome).ToList();
            foreach (var disciplina in disciplinas)
            {
                var professorNome = disciplina.Professor?.Nome ?? "N/A";
                var cursoNome = disciplina.Curso?.Nome ?? "N/A";
                Console.WriteLine($"Id: {disciplina.Id}. Disciplina: {disciplina.Nome}. Professor(a): {professorNome}, Curso: {cursoNome}, Tipo: {disciplina.Tipo}");
            }
            EnterParaContinuar("-----------------------------------");
            MenuDisciplina();
        }

        public static void ConsultarDisciplina()
        {
            CriarTitulo("Sapiens - Consultar Disciplina");
            var termo = LeiaTexto("Pesquise por nome disciplina");
            termo = termo.ToLower();
            var disciplinas = context.Disciplinas.Include(d => d.Curso).Where(c => c.Nome != null && c.Nome.ToLower().Contains(termo)).ToList();
            foreach (var disciplina in disciplinas)
            {
                var cursoNome = disciplina.Curso?.Nome ?? "N/A";
                Console.WriteLine($"Id: {disciplina.Id}. Disciplina: {disciplina.Nome}, Curso: {cursoNome}, Tipo: {disciplina.Tipo}");
            }
            EnterParaContinuar("-----------------------------------");
            MenuDisciplina();
        }

        public static void AdicionarDisciplina()
        {
            CriarTitulo("Sapiens - Adicionar Disciplina");
            var nome = LeiaTexto("Nome da Disciplina");
            var cursoId = 0;

            while (true)
            {
                ListarRemocaoCursos();
                var cursoIdInput = LeiaTexto("Informe o ID do Curso");

                if (string.IsNullOrEmpty(cursoIdInput))
                {
                    break;
                }

                if (int.TryParse(cursoIdInput, out cursoId))
                {
                    var curso = context.Cursos.Find(cursoId);
                    if (curso != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Curso inexistente, por favor, informe um ID válido.");
                    }
                }
                else
                {
                    Console.WriteLine("ID do curso inválido, por favor, informe um número válido.");
                }
            }

            var tipo = SelecionarTipoDisciplina();

            var disciplina = new Disciplina()
            {
                Nome = nome,
                Tipo = tipo
            };

            if (cursoId != 0)
            {
                disciplina.CursoId = cursoId;
            }

            ListarRemocaoProfessores();
            var cpf = LeiaTexto("Cpf do Professor");
            if (!string.IsNullOrEmpty(cpf))
            {
                var professor = context.Professores.FirstOrDefault(p => p.Cpf == cpf);
                if (professor != null)
                    disciplina.Professor = professor;
                else
                    Console.WriteLine("Professor inexistente, disciplina não atribuída.");
            }
            context.Add(disciplina);
            context.SaveChanges();
            EnterParaContinuar("-----------------------------------\nDisciplina Adicionada");
            MenuDisciplina();
        }

        public static void RemoverDisciplina()
        {
            CriarTitulo("Sapiens - Remover Disciplina");
            ListarRemocaoDisciplinas();
            var id = LeiaInteiro("Id da Disciplina");
            var disciplina = context.Disciplinas.Find(id);
            if (disciplina != null)
            {
                context.Remove(disciplina);
                context.SaveChanges();
                Console.WriteLine("Disciplina excluída.");
            }
            else
            {
                Console.WriteLine("Disciplina inexistente.");
            }
            EnterParaContinuar("-----------------------------------");
            MenuDisciplina();
        }

        private static TipoDisciplina SelecionarTipoDisciplina()
        {
            Console.WriteLine("Selecione o tipo da disciplina:");
            foreach (var tipo in Enum.GetValues(typeof(TipoDisciplina)))
            {
                Console.WriteLine($" [{(int)tipo}] {tipo}");
            }
            var opcao = LeiaInteiro("Opção");
            return (TipoDisciplina)opcao;
        }
    }
}
