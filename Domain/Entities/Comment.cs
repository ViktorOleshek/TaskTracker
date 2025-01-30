namespace Domain.Entities;
public class Comment : BaseEntity
{
    public string Data { get; set; } = string.Empty;
    public Guid TaskId { get; set; }
}