using Microsoft.EntityFrameworkCore;
using Sapiens.Shared.Entities;
using System.Globalization;

namespace Sapiens.Shared.Contexts;

public class SapiensContext : DbContext
{
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Disciplina> Disciplinas { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }

    private string caminhoDb;

    public SapiensContext()
    {
        var folder = Environment.SpecialFolder.MyDocuments;
        var path = Environment.GetFolderPath(folder);
        caminhoDb = Path.Join(path, "sapiens.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={caminhoDb}");
}