using Sapiens.Shared.Entities;

namespace Sapiens.Shared.Helpers;

public static partial class ConsoleHelper
{
    public static void MenuProfessor()
    {
        CriarTitulo("Sapiens - Cadastro de Professores");
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
            case "1": ListarProfessores(); break;
            case "2": ConsultarProfessores(); break;
            case "3": AdicionarProfessor(); break;
            case "4": RemoverProfessor(); break;
            case "9": Menu(); break;
        }
    }

    public static void ListarProfessores()
    {
        CriarTitulo("Sapiens - Lista de Professores");
        var professores = context.Professores.OrderBy(p => p.Nome).ToList();
        foreach (var professor in professores)
        {
            Console.WriteLine($"{professor.Cpf} - {professor.Nome}");
        }
        EnterParaContinuar("-----------------------------------");
        MenuProfessor();
    }

    public static void ConsultarProfessores()
    {
        CriarTitulo("Sapiens - Consultar Professor");
        var termo = LeiaTexto("Termo de pesquisa");
        termo = termo.ToLower();
        var professores = context.Professores
            .Where(p => (p.Nome.ToLower().Contains(termo)) || p.Cpf.Contains(termo))
            .OrderBy(p => p.Nome)
            .ToList();
        foreach (var professor in professores)
        {
            Console.WriteLine($"{professor.Nome} ({professor.Cpf})");
        }
        EnterParaContinuar("-----------------------------------");
        MenuProfessor();
    }

    public static void AdicionarProfessor()
    {
        CriarTitulo("Sapiens - Adicionar Professor");
        var nome = LeiaTexto("Nome do Professor");
        var cpf = LeiaTexto("Cpf");

        var professor = new Professor()
        {
            Nome = nome,
            Cpf = cpf
        };
        context.Add(professor);
        context.SaveChanges();
        EnterParaContinuar("-----------------------------------\nProfessor Adicionado");
        MenuProfessor();
    }

    public static void RemoverProfessor()
    {
        CriarTitulo("Sapiens - Remover Professor");
        var id = LeiaInteiro("Id do Professor");
        var professor = context.Professores.Find(id);
        if (professor != null)
        {
            context.Remove(professor);
            context.SaveChanges();
            Console.WriteLine("Professor excluído.");
        }
        else
        {
            Console.WriteLine("Professor inexistente.");
        }
        EnterParaContinuar("-----------------------------------");
        MenuProfessor();
    }

}