
using Microsoft.EntityFrameworkCore;
using Sapiens.Shared.Entities;

namespace Sapiens.Shared.Helpers;

public static partial class ConsoleHelper
{
    public static void MenuCurso()
    {
        CriarTitulo("Sapiens - Cadastro de Cursos");
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
            case "1": ListarCursos(); break;
            case "2": ConsultarCurso(); break;
            case "3": AdicionarCurso(); break;
            case "4": RemoverCurso(); break;
            case "9": Menu(); break;
        }
    }

    public static void ListarCursos()
    {
        CriarTitulo("Sapiens - Lista de Cursos");
        var cursos = context.Cursos.Include(c => c.Coordenador).OrderBy(c => c.Nome).ToList();
        foreach (var curso in cursos)
        {
            Console.WriteLine($"{curso.Id}. {curso}");
        }
        EnterParaContinuar("-----------------------------------");
        MenuCurso();
    }

    public static void ListarRemocaoCursos()
    {
        CriarTitulo("Sapiens - Lista de Cursos");
        var cursos = context.Cursos.Include(c => c.Coordenador).OrderBy(c => c.Nome).ToList();
        foreach (var curso in cursos)
        {
            Console.WriteLine($"ID: {curso.Id}. Curso: {curso}");
        }
        Console.WriteLine("-----------------------------------");
    }

    public static void ConsultarCurso()
    {
        CriarTitulo("Sapiens - Consultar Curso");
        var termo = LeiaTexto("Termo de pesquisa");
        termo = termo.ToLower();
        var cursos = context.Cursos.Where(c => c.Nome != null && c.Nome.ToLower().Contains(termo)).ToList();
        foreach (var curso in cursos)
        {
            Console.WriteLine($"{curso.Nome} ({curso.CargaHoraria}h)");
        }
        EnterParaContinuar("-----------------------------------");
        MenuCurso();
    }

    public static void AdicionarCurso()
    {
        CriarTitulo("Sapiens - Adicionar Curso");
        var nome = LeiaTexto("Nome do Curso");
        var ch = LeiaInteiro("Carga Horária");
        var curso = new Curso()
        {
            Nome = nome,
            CargaHoraria = ch
        };

        var cpf = LeiaTexto("Cpf do Coordenador");
        if (cpf != "")
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

    public static void RemoverCurso()
    {
        CriarTitulo("Sapiens - Remover Curso");
        ListarRemocaoCursos();
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

}
