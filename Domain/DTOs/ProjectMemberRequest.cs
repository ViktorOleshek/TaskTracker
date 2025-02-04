namespace Domain.DTOs;

public class ProjectMemberRequest
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
};