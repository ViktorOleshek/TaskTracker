using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Comments")]
public class Comment : TrackableEntity
{
    public string Data { get; set; } = string.Empty;
    public Guid TaskId { get; set; }
}