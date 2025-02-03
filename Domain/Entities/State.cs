using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("States")]
public class State : BaseEntity
{
    public Guid ProjectId { get; set; }
    public int Number { get; set; }
    public string Name { get; set; } = string.Empty;
}