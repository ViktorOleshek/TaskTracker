using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Projects")]
public class Project : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
}