using Sapiens.Shared.Entities;

namespace Sapiens.Shared.Helpers;

public static partial class ConsoleHelper
{
    public static void MenuAluno()
    {
        CriarTitulo("Sapiens - Cadastro de Alunos");
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
            case "1": ListarAlunos(); break;
            case "2": ConsultarAlunos(); break;
            case "3": AdicionarAlunos(); break;
            case "4": EditarAlunos(); break;
            case "5": RemoverAlunos(); break;
            case "9": Menu(); break;
        }
    }


    public static void ListarRemocaoAlunos()
    {
        CriarTitulo("Sapiens - Lista de Alunos");
        var alunos = context.Alunos.OrderBy(a => a.Nome).ToList();
        foreach (var aluno in alunos)
        {
            Console.WriteLine($"Aluno(a): {aluno.Cpf} - {aluno.Nome}");
        }
    }

    public static void ListarAlunos()
    {
        CriarTitulo("Sapiens - Lista de Alunos");
        var alunos = context.Alunos.OrderBy(a => a.Nome).ToList();
        foreach (var aluno in alunos)
        {
            Console.WriteLine($"{aluno.Cpf} - {aluno.Nome}");
        }
        EnterParaContinuar("-----------------------------------");
        MenuAluno();
    }

    public static void ConsultarAlunos()
    {
        CriarTitulo("Sapiens - Consultar Aluno");
        var termo = LeiaTexto("Pesquise por CPF ou Nome");
        termo = termo.ToLower();
        var alunos = context.Alunos
            .Where(a => (a.Nome.ToLower().Contains(termo)) || a.Cpf.Contains(termo))
            .OrderBy(a => a.Nome)
            .ToList();
        foreach (var aluno in alunos)
        {
            Console.WriteLine($"{aluno.Nome} ({aluno.Cpf})");
        }
        EnterParaContinuar("-----------------------------------");
        MenuAluno();
    }

    public static void AdicionarAlunos()
    {
        CriarTitulo("Sapiens - Adicionar Aluno");
        var nome = LeiaTexto("Nome do Aluno");
        var cpf = LeiaTexto("Cpf");

        var aluno = new Aluno()
        {
            Nome = nome,
            Cpf = cpf
        };
        context.Add(aluno);
        context.SaveChanges();
        EnterParaContinuar("-----------------------------------\nAluno Adicionado");
        MenuAluno();
    }

    public static void EditarAlunos()
    {
        CriarTitulo("Sapiens - Editar Aluno");
        ListarRemocaoAlunos();
        var cpf = LeiaTexto("Cpf do Aluno a Editar");
        var aluno = context.Alunos.FirstOrDefault(a => a.Cpf == cpf);
        if (aluno != null)
        {
            var novoNome = LeiaTexto($"Novo Nome do Aluno (Atual: {aluno.Nome})");
            aluno.Nome = string.IsNullOrEmpty(novoNome) ? aluno.Nome : novoNome;

            var novoCpf = LeiaTexto($"Novo Cpf do Aluno (Atual: {aluno.Cpf})");
            aluno.Cpf = string.IsNullOrEmpty(novoCpf) ? aluno.Cpf : novoCpf;

            context.Update(aluno);
            context.SaveChanges();
            Console.WriteLine("Aluno atualizado.");
        }
        else
        {
            Console.WriteLine("Aluno inexistente.");
        }
        EnterParaContinuar("-----------------------------------");
        MenuAluno();
    }

    public static void RemoverAlunos()
    {
        CriarTitulo("Sapiens - Remover Aluno");
        ListarRemocaoAlunos();
        var cpf = LeiaTexto("Cpf do Aluno");
        var aluno = context.Alunos.FirstOrDefault(a => a.Cpf == cpf);
        if (aluno != null)
        {
            context.Remove(aluno);
            context.SaveChanges();
            Console.WriteLine("Aluno excluído.");
        }
        else
        {
            Console.WriteLine("Aluno inexistente.");
        }
        EnterParaContinuar("-----------------------------------");
        MenuAluno();
    }

}