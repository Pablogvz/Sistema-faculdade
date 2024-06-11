using Sapiens.Shared.Entities;
using Sapiens.Shared.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sapiens.Shared.Helpers;

public static partial class ConsoleHelper
{
    public static void MenuMatricula()
    {
        CriarTitulo("Sapiens - Cadastro de Matrícula");
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
            case "1": ListarMatriculas(); break;
            case "2": ConsultarMatricula(); break;
            case "3": AdicionarMatricula(); break;
            case "4": RemoverMatricula(); break;
            case "9": Menu(); break;
            default:
                Console.WriteLine("Opção inválida");
                EnterParaContinuar();
                MenuMatricula();
                break;
        }
    }

    public static void ListarMatriculas()
    {
        CriarTitulo("Sapiens - Lista de Matrículas");
        var matriculas = context.Matriculas.Include(m => m.Aluno).Include(m => m.Disciplina).ToList();
        foreach (var matricula in matriculas)
        {
            Console.WriteLine($"{matricula.Id}. Aluno(a): {matricula.Aluno.Nome}. Disciplina: {matricula.Disciplina.Nome}. Ano: {matricula.Ano}");
        }
        EnterParaContinuar("-----------------------------------");
        MenuMatricula();
    }

    public static void ListarRemocaoMatriculas()
    {
        CriarTitulo("Sapiens - Lista de Matrículas");
        var matriculas = context.Matriculas.Include(m => m.Aluno).Include(m => m.Disciplina).ToList();
        foreach (var matricula in matriculas)
        {
            Console.WriteLine($"ID: {matricula.Id}. Matrícula: {matricula.Aluno.Nome} - {matricula.Disciplina.Nome}. Ano: {matricula.Ano}");
        }
        Console.WriteLine("-----------------------------------");
    }

    public static void ConsultarMatricula()
    {
        CriarTitulo("Sapiens - Consultar Matrícula");
        var termo = LeiaTexto("Pesquise por nome do Aluno ou da disciplina");
        termo = termo.ToLower();
        var matriculas = context.Matriculas.Include(m => m.Aluno).Include(m => m.Disciplina)
                                            .Where(m => m.Aluno.Nome.ToLower().Contains(termo) ||
                                                        m.Disciplina.Nome.ToLower().Contains(termo))
                                            .ToList();
        foreach (var matricula in matriculas)
        {
            Console.WriteLine($"{matricula.Aluno.Nome} - {matricula.Disciplina.Nome} ({matricula.Ano})");
        }
        EnterParaContinuar("-----------------------------------");
        MenuMatricula();
    }

    public static void AdicionarMatricula()
    {
        CriarTitulo("Sapiens - Adicionar Matrícula");

        ListarRemocaoAlunos();
        var cpfAluno = LeiaTexto("CPF do aluno");
        var aluno = context.Alunos.FirstOrDefault(a => a.Cpf == cpfAluno);
        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado");
            EnterParaContinuar("-----------------------------------");
            MenuMatricula();
            return;
        }

        ListarRemocaoDisciplinas();
        var idDisciplina = LeiaInteiro("Informe o id da Disciplina:");
        var disciplina = context.Disciplinas.FirstOrDefault(d => d.Id == idDisciplina);
        if (disciplina == null)
        {
            Console.WriteLine("Disciplina não encontrada.");
            EnterParaContinuar("-----------------------------------");
            MenuMatricula();
            return;
        }

        var ano = LeiaInteiro("Informe o Ano");

        var matricula = new Matricula()
        {
            AlunoId = aluno.Id,
            Aluno = aluno,
            DisciplinaId = disciplina.Id,
            Disciplina = disciplina,
            Ano = ano
        };

        context.Add(matricula);
        context.SaveChanges();
        EnterParaContinuar("-----------------------------------\nMatrícula Adicionada");
        MenuMatricula();
    }

    public static void RemoverMatricula()
    {
        CriarTitulo("Sapiens - Remover Matrícula");
        ListarRemocaoMatriculas();
        var id = LeiaInteiro("Id da matrícula");
        var matricula = context.Matriculas.Find(id);
        if (matricula != null)
        {
            context.Remove(matricula);
            context.SaveChanges();
            Console.WriteLine("Matrícula excluída.");
        }
        else
        {
            Console.WriteLine("Matrícula inexistente.");
        }
        EnterParaContinuar("-----------------------------------");
        MenuMatricula();
    }
}
