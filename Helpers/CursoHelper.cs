using Microsoft.EntityFrameworkCore;
using Sapiens.Shared.Entities;
using Sapiens.Shared.Enums;
using System;
using System.Linq;

namespace Sapiens.Shared.Helpers
{
    public static partial class ConsoleHelper
    {
        public static void MenuCurso()
        {
            CriarTitulo("Sapiens - Cadastro de Cursos");
            var opcao = "";
            Console.WriteLine(" [1] Listar");
            Console.WriteLine(" [2] Consultar");
            Console.WriteLine(" [3] Adicionar");
            Console.WriteLine(" [4] Editar");
            Console.WriteLine(" [5] Remover");
            Console.WriteLine("\n [9] Voltar");
            Console.WriteLine("-----------------------------------");
            Console.Write(" \nOpção: ");
            opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1": ListarCursos(); break;
                case "2": ConsultarCurso(); break;
                case "3": AdicionarCurso(); break;
                case "4": EditarCurso(); break;
                case "5": RemoverCurso(); break;
                case "9": Menu(); break;
            }
        }

        public static void ListarCursos()
        {
            CriarTitulo("Sapiens - Lista de Cursos");
            var cursos = context.Cursos.Include(c => c.Coordenador).OrderBy(c => c.Nome).ToList();
            foreach (var curso in cursos)
            {
                var coordenadorNome = curso.Coordenador?.Nome ?? "N/A";
                Console.WriteLine($"ID: {curso.Id}. Curso: {curso.Nome}. Coordenador: {coordenadorNome}, Tipo: {curso.Tipo}");
            }
            EnterParaContinuar("-----------------------------------");
            MenuCurso();
        }

        public static void ListarAcaoCursos()
        {
            CriarTitulo("Sapiens - Lista de Cursos");
            var cursos = context.Cursos.Include(c => c.Coordenador).OrderBy(c => c.Nome).ToList();
            foreach (var curso in cursos)
            {
                var coordenadorNome = curso.Coordenador?.Nome ?? "N/A";
                Console.WriteLine($"ID: {curso.Id}. Curso: {curso.Nome}. Coordenador: {coordenadorNome}, Tipo: {curso.Tipo}");
            }
            Console.WriteLine("-----------------------------------");
        }

        public static void ListarCoordenadores()
        {
            CriarTitulo("Sapiens - Lista de Coordenadores");
            var coordenadores = context.Professores.OrderBy(p => p.Nome).ToList();
            foreach (var coordenador in coordenadores)
            {
                Console.WriteLine($"CPF: {coordenador.Cpf} - Nome: {coordenador.Nome}");
            }
            Console.WriteLine("-----------------------------------");
        }

        public static void ConsultarCurso()
        {
            CriarTitulo("Sapiens - Consultar Curso");
            var termo = LeiaTexto("Pesquise por Nome do Curso");
            termo = termo.ToLower();
            var cursos = context.Cursos.Where(c => c.Nome != null && c.Nome.ToLower().Contains(termo)).ToList();
            foreach (var curso in cursos)
            {
                Console.WriteLine($"ID: {curso.Id}. Curso: {curso.Nome} ({curso.CargaHoraria}h), Tipo: {curso.Tipo}");
            }
            EnterParaContinuar("-----------------------------------");
            MenuCurso();
        }

        public static void AdicionarCurso()
        {
            CriarTitulo("Sapiens - Adicionar Curso");
            var nome = LeiaTexto("Nome do Curso");
            var ch = LeiaInteiro("Carga Horária");
            var tipo = SelecionarTipoCurso();

            var curso = new Curso()
            {
                Nome = nome,
                CargaHoraria = ch,
                Tipo = tipo
            };

            ListarCoordenadores();
            var cpf = LeiaTexto("Cpf do Coordenador");
            if (!string.IsNullOrEmpty(cpf))
            {
                var coordenador = context.Professores.FirstOrDefault(p => p.Cpf == cpf);
                if (coordenador != null)
                    curso.Coordenador = coordenador;
                else
                    Console.WriteLine("Professor inexistente, coordenador não atribuído.");
            }
            context.Add(curso);
            context.SaveChanges();
            EnterParaContinuar("-----------------------------------\nCurso Adicionado");
            MenuCurso();
        }

        public static void EditarCurso()
        {
            CriarTitulo("Sapiens - Editar Curso");
            ListarAcaoCursos();
            var id = LeiaInteiro("Id do Curso a ser editado");
            var curso = context.Cursos.Include(c => c.Coordenador).FirstOrDefault(c => c.Id == id);
            if (curso != null)
            {
                Console.WriteLine("Deixe o campo em branco para manter o valor atual.");
                var nome = LeiaTexto($"Nome do Curso ({curso.Nome})");
                if (!string.IsNullOrEmpty(nome))
                    curso.Nome = nome;

                var ch = LeiaInteiro($"Carga Horária ({curso.CargaHoraria})");
                curso.CargaHoraria = ch;

                var tipo = SelecionarTipoCurso();
                curso.Tipo = tipo;

                ListarCoordenadores();
                var cpf = LeiaTexto($"Cpf do Coordenador ({curso.Coordenador?.Cpf ?? "N/A"})");
                if (!string.IsNullOrEmpty(cpf))
                {
                    var coordenador = context.Professores.FirstOrDefault(p => p.Cpf == cpf);
                    if (coordenador != null)
                        curso.Coordenador = coordenador;
                    else
                        Console.WriteLine("Professor inexistente, coordenador não atribuído.");
                }

                context.Update(curso);
                context.SaveChanges();
                EnterParaContinuar("-----------------------------------\nCurso Editado");
            }
            else
            {
                Console.WriteLine("Curso inexistente.");
            }
            MenuCurso();
        }

        public static void RemoverCurso()
        {
            CriarTitulo("Sapiens - Remover Curso");
            ListarAcaoCursos();
            var id = LeiaInteiro("Id do Curso");
            var curso = context.Cursos.Find(id);
            if (curso != null)
            {
                context.Remove(curso);
                context.SaveChanges();
                Console.WriteLine("Curso excluído.");
            }
            else
            {
                Console.WriteLine("Curso inexistente.");
            }
            EnterParaContinuar("-----------------------------------");
            MenuCurso();
        }

        private static TipoCurso SelecionarTipoCurso()
        {
            Console.WriteLine("Selecione o tipo do curso:");
            foreach (var tipo in Enum.GetValues(typeof(TipoCurso)))
            {
                Console.WriteLine($" [{(int)tipo}] {tipo}");
            }
            var opcao = LeiaInteiro("Opção");
            return (TipoCurso)opcao;
        }
    }
}
