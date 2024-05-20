using Sapiens.Shared.Entities;
using Sapiens.Shared.Enums;

var curso = new Curso("Sistemas da informação \n\n");
Console.WriteLine(curso.ToString());

var pessoa = new Pessoa
{
    Nome = "João Silva",
    Idade = 30,
    Cpf = "123.456.789-00",
    Sexo = TipoSexo.Masculino,
    Cep = "12345-678",
    Email = "joao.silva@example.com",
    Telefone = "(11) 91234-5678"
};
Console.WriteLine($"Pessoa: Nome = {pessoa.Nome}, Idade = {pessoa.Idade}, CPF = {pessoa.Cpf}, Sexo = {pessoa.Sexo}, CEP = {pessoa.Cep}, Email = {pessoa.Email}, Celular = {pessoa.Telefone} \n\n");

var funcionario = new Funcionario
{
    Nome = "Maria Santos",
    Idade = 28,
    Cpf = "987.654.321-00",
    Sexo = TipoSexo.Feminino,
    Cep = "98765-432",
    Email = "maria.santos@example.com",
    Telefone = "(11) 99876-5432",
    Salario = 5000.00m
};
Console.WriteLine($"Funcionario: Nome = {funcionario.Nome}, Idade = {funcionario.Idade}, CPF = {funcionario.Cpf}, Sexo = {funcionario.Sexo}, CEP = {funcionario.Cep}, Email = {funcionario.Email}, Celular = {funcionario.Telefone}, Salario = {funcionario.Salario} \n\n");

// Criando e testando uma instância de Professor
var professor = new Professor
{
    Nome = "Carlos Pereira",
    Idade = 40,
    Cpf = "456.789.123-00",
    Sexo = TipoSexo.Masculino,
    Cep = "45678-123",
    Email = "carlos.pereira@example.com",
    Telefone = "(11) 93456-7890",
    Salario = 7000.00m,
    CargaHoraria = 20,
    Curso = curso
};
Console.WriteLine($"Professor: Nome = {professor.Nome}, Idade = {professor.Idade}, CPF = {professor.Cpf}, Sexo = {professor.Sexo}, CEP = {professor.Cep}, Email = {professor.Email}, Celular = {professor.Telefone}, Salario = {professor.Salario}, Carga Horaria = {professor.CargaHoraria}, Curso = {professor.Curso} \n");

// Criando e testando uma instância de Coordenador
var coordenador = new Coordenador
{
    Nome = "Ana Costa",
    Idade = 35,
    Cpf = "321.654.987-00",
    Sexo = TipoSexo.Feminino,
    Cep = "65432-198",
    Email = "ana.costa@example.com",
    Telefone = "(11) 97654-3210",
    Salario = 8000.00m,
    CargaHoraria = 25,
    Curso = curso,
    Gratificacao = 1000.00m
};
Console.WriteLine($"Coordenador: Nome = {coordenador.Nome}, Idade = {coordenador.Idade}, CPF = {coordenador.Cpf}, Sexo = {coordenador.Sexo}, CEP = {coordenador.Cep}, Email = {coordenador.Email}, Celular = {coordenador.Telefone}, Salario = {coordenador.Salario}, Carga Horaria = {coordenador.CargaHoraria}, Curso = {coordenador.Curso}, Gratificação = {coordenador.Gratificacao}");