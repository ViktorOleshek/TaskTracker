namespace Domain.Entities;
public class Activity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
}