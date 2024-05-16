using Sapiens.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sapiens.Shared.Entities;

public class Disciplina
{
    [StringLength(100)]
    public required string Nome { get; set; }

    public TipoDisciplina Tipo { get; set; }
}