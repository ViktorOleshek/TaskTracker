using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Projects")]
public class Project : TrackableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
}