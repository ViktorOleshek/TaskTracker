namespace Domain.Entities;
public class State : BaseEntity
{
    public Guid ProjectId { get; set; }
    public int Number { get; set; }
    public string Name { get; set; } = string.Empty;
}