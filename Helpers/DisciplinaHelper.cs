
using Microsoft.EntityFrameworkCore;
using Sapiens.Shared.Entities;

namespace Sapiens.Shared.Helpers;

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

    public static void ListarDisciplinas()
    {
        CriarTitulo("Sapiens - Lista de Disciplinas");
        var disciplinas = context.Disciplinas.OrderBy(c => c.Nome).ToList();
        foreach (var disciplina in disciplinas)
        {
            Console.WriteLine($"{disciplina.Id}. {disciplina}");
        }
        EnterParaContinuar("-----------------------------------");
        MenuDisciplina();
    }

    public static void ConsultarDisciplina()
    {
        CriarTitulo("Sapiens - Consultar Disciplina");
        var termo = LeiaTexto("Termo de pesquisa");
        termo = termo.ToLower();
        var disciplinas = context.Disciplinas.Where(c => c.Nome != null && c.Nome.ToLower().Contains(termo)).ToList();
        foreach (var disciplina in disciplinas)
        {
            Console.WriteLine($"{disciplina.Nome} - {disciplina.Tipo} \nprofessor: {disciplina?.Professor?.Nome}");
        }
        EnterParaContinuar("-----------------------------------");
        MenuDisciplina();
    }

    public static void AdicionarDisciplina()
    {
        CriarTitulo("Sapiens - Adicionar Disciplina");
        var nome = LeiaTexto("Nome do Disciplina");
        var disciplina = new Disciplina()
        {
            Nome = nome
        };

        var cpf = LeiaTexto("Cpf do Professor");
        if (cpf != "")
        {
            var professor = context.Professores.FirstOrDefault(p => p.Cpf == cpf);
            if (professor != null)
                disciplina.Professor = professor;
            else
                Console.WriteLine("Professor inexistente, coordenador não atribuído.");
        }
        context.Add(disciplina);
        context.SaveChanges();
        EnterParaContinuar("-----------------------------------\nCurso Adicionado");
        MenuDisciplina();
    }

    public static void RemoverDisciplina()
    {
        CriarTitulo("Sapiens - Remover Disciplina");
        var id = LeiaInteiro("Id do Disciplina");
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

}