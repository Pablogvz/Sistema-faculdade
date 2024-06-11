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
        Console.WriteLine(" [4] Editar");
        Console.WriteLine(" [5] Remover");
        Console.WriteLine("\n [9] Voltar");
        Console.WriteLine("-----------------------------------");
        Console.Write(" \nOpção: ");
        opcao = Console.ReadLine();
        switch (opcao)
        {
            case "1": ListarProfessores(); break;
            case "2": ConsultarProfessores(); break;
            case "3": AdicionarProfessor(); break;
            case "4": EditarProfessor(); break;
            case "5": RemoverProfessor(); break;
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

    public static void ListarRemocaoProfessores()
    {
        CriarTitulo("Sapiens - Lista de Professores");
        var professores = context.Professores.OrderBy(p => p.Nome).ToList();
        foreach (var professor in professores)
        {
            Console.WriteLine($"Professor(a):{professor.Cpf} - {professor.Nome}");
        }
        Console.WriteLine("-----------------------------------");
    }

    public static void ConsultarProfessores()
    {
        CriarTitulo("Sapiens - Consultar Professor");
        var termo = LeiaTexto("Pesquise por CPF ou Nome");
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

    public static void EditarProfessor()
    {
        CriarTitulo("Sapiens - Editar Professor");
        ListarRemocaoProfessores();
        var cpf = LeiaTexto("Cpf do Professor a Editar");
        var professor = context.Professores.FirstOrDefault(p => p.Cpf == cpf);
        if (professor != null)
        {
            var novoNome = LeiaTexto($"Novo Nome do Professor (Atual: {professor.Nome})");
            professor.Nome = string.IsNullOrEmpty(novoNome) ? professor.Nome : novoNome;

            var novoCpf = LeiaTexto($"Novo Cpf do Professor (Atual: {professor.Cpf})");
            professor.Cpf = string.IsNullOrEmpty(novoCpf) ? professor.Cpf : novoCpf;

            context.Update(professor);
            context.SaveChanges();
            Console.WriteLine("Professor atualizado.");
        }
        else
        {
            Console.WriteLine("Professor inexistente.");
        }
        EnterParaContinuar("-----------------------------------");
        MenuProfessor();
    }

    public static void RemoverProfessor()
    {
        CriarTitulo("Sapiens - Remover Professor");
        ListarRemocaoProfessores();
        var cpf = LeiaTexto("CPF do Professor(a):");
        var professor = context.Professores.FirstOrDefault(a => a.Cpf == cpf);
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