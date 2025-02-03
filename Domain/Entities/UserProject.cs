using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("UserProjects")]
public class UserProject
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public Guid RoleId { get; set; }
}