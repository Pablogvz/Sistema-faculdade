using Sapiens.Shared.Entities;
using Sapiens.Shared.Enums; // Ensure this includes TipoSexo

namespace Sapiens.Shared.Helpers
{
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

        public static void ListarAcaoAlunos()
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
                Console.WriteLine($"{aluno.Cpf} - {aluno.Nome}, Sexo: {aluno.Sexo}");
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
                Console.WriteLine($"{aluno.Nome} ({aluno.Cpf}), Sexo: {aluno.Sexo}");
            }
            EnterParaContinuar("-----------------------------------");
            MenuAluno();
        }

        public static void AdicionarAlunos()
        {
            CriarTitulo("Sapiens - Adicionar Aluno");
            var nome = LeiaTexto("Nome do Aluno");
            var cpf = LeiaTexto("Cpf");
            var sexo = SelecionarTipoSexo();

            var aluno = new Aluno()
            {
                Nome = nome,
                Cpf = cpf,
                Sexo = sexo
            };
            context.Add(aluno);
            context.SaveChanges();
            EnterParaContinuar("-----------------------------------\nAluno Adicionado");
            MenuAluno();
        }

        public static void EditarAlunos()
        {
            CriarTitulo("Sapiens - Editar Aluno");
            ListarAcaoAlunos();
            var cpf = LeiaTexto("Cpf do Aluno a Editar");
            var aluno = context.Alunos.FirstOrDefault(a => a.Cpf == cpf);
            if (aluno != null)
            {
                var novoNome = LeiaTexto($"Novo Nome do Aluno (Atual: {aluno.Nome})");
                aluno.Nome = string.IsNullOrEmpty(novoNome) ? aluno.Nome : novoNome;

                var novoCpf = LeiaTexto($"Novo Cpf do Aluno (Atual: {aluno.Cpf})");
                aluno.Cpf = string.IsNullOrEmpty(novoCpf) ? aluno.Cpf : novoCpf;

                var sexo = SelecionarTipoSexo();
                aluno.Sexo = sexo;

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
            ListarAcaoAlunos();
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

        private static TipoSexo SelecionarTipoSexo()
        {
            Console.WriteLine("Selecione o sexo do aluno:");
            foreach (var tipo in Enum.GetValues(typeof(TipoSexo)))
            {
                Console.WriteLine($" [{(int)tipo}] {tipo}");
            }
            var opcao = LeiaInteiro("Opção");
            return (TipoSexo)opcao;
        }
    }
}
