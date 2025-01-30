namespace Domain.Entities;
public class Task : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public Guid ProjectId { get; set; }
    public Guid StateId { get; set; }
    public Guid? UserId { get; set; }
}