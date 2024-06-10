using Sapiens.Shared.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Sapiens.Shared.Helpers;

public static partial class ConsoleHelper
{
    public static SapiensContext context = new();

    public static void Menu()
    {
        CriarTitulo("Sapiens - Sistema Acadêmico");
        Console.WriteLine(" [1] Cursos");
        Console.WriteLine(" [2] Disciplinas");
        Console.WriteLine(" [3] Professores");
        Console.WriteLine(" [4] Alunos");
        Console.WriteLine(" [5] Matricula");
        Console.WriteLine(" [6] Fazer Migração");
        Console.WriteLine("\n [7] Sair");
        Console.WriteLine("-----------------------------------");
        Console.Write(" \nOpção: ");
        var opcao = Console.ReadLine();
        switch (opcao)
        {
            case "1": MenuCurso(); break;
            case "2": MenuDisciplina(); break;
            case "3": MenuProfessor(); break;
            case "4": MenuAluno(); break;
            case "5": MenuAluno(); break;
            case "6": FazerMigracao(); break;
            case "7": return;
            default:
                Console.WriteLine("Opção inválida");
                EnterParaContinuar();
                Menu();
                break;
        }
    }

    public static void FazerMigracao()
    {
        Console.WriteLine("Iniciando migração");
        context.Database.Migrate();
        Console.WriteLine("Migração Finalizada");
    }

    public static void EnterParaContinuar(string? mensagem = null)
    {
        if (mensagem != null)
            Console.WriteLine(mensagem);
        Console.WriteLine("[Enter] para continuar");
        Console.ReadLine();
    }

    public static void NaoImplentado()
    {
        EnterParaContinuar("Funcionalidade ainda não implementada.");
    }

    public static void CriarTitulo(string titulo)
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($" {titulo}");
        Console.WriteLine("-----------------------------------");
    }

    public static string LeiaTexto(string rotulo)
    {
        Console.Write($"{rotulo}: ");
        var entrada = Console.ReadLine();
        return entrada ?? "";
    }

    public static int LeiaInteiro(string rotulo)
    {
        Console.Write($"{rotulo}: ");
        var entrada = Console.ReadLine();
        return entrada != null ? Convert.ToInt32(entrada) : 0;
    }

    public static double LeiaReal(string rotulo)
    {
        Console.Write($"{rotulo}: ");
        var entrada = Console.ReadLine();
        return entrada != null ? Convert.ToDouble(entrada) : 0;
    }
}
