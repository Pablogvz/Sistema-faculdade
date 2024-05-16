using Sapiens.Shared.Entities;

namespace Sapiens.Shared.Contexts;

public class SapiensContext
{
    public List<Curso> Cursos { get; set; }
    public List<Disciplina> Disciplinas { get; set; }

    public SapiensContext()
    {
        Cursos = new();
        Disciplinas = new();
    }
}