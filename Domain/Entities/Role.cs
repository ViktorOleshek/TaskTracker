using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Roles")]
public class Role : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}