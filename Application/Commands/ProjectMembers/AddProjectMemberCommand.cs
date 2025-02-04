using MediatR;
using FluentResults;
using Domain.DTOs;

namespace Application.Commands.ProjectMembers;

public class AddProjectMemberCommand : IRequest<Result<ProjectMemberDto>>
{
    public Guid UserId { get; }
    public Guid ProjectId { get; }
    public Guid RoleId { get; }

    public AddProjectMemberCommand(Guid userId, Guid projectId, Guid roleId)
    {
        UserId = userId;
        ProjectId = projectId;
        RoleId = roleId;
    }
}
