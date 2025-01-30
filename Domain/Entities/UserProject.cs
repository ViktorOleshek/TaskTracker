namespace Domain.Entities;
public class UserProject
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public Guid RoleId { get; set; }
}