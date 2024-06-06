namespace Sapiens.Shared.Entities;

public class Matricula : Entidade
{
    public int AlunoId { get; set; }
    public required Aluno Aluno { get; set; }

    public int DisciplinaId { get; set; }
    public required Disciplina Disciplina { get; set; }

    public int Ano { get; set; }
}