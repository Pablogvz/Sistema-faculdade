using System.ComponentModel.DataAnnotations;

namespace Sapiens.Shared.Entities;

public abstract class Entidade
{
    [Key]
    public int Id { get; set; }

    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

}