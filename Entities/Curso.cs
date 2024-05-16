
using Sapiens.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sapiens.Shared.Entities;

public class Curso
{
    [StringLength(100)]
    public string Nome { get; set; }

    public int? CargaHoraria { get; set; }

    public TipoCurso Tipo { get; set; }

    public Curso(string nome)
    {
        Nome = nome;
    }

    public override string ToString()
    {
        return Nome;
    }
}
