using FluentResults;
using MediatR;

namespace Application.Commands.ProjectMembers;

public class UpdateProjectMemberRoleCommand : IRequest<Result<bool>>
{
    public Guid MemberId { get; }
    public Guid ProjectId { get; }
    public Guid RoleId { get; }

    public UpdateProjectMemberRoleCommand(Guid memberId, Guid projectId, Guid roleId)
    {
        MemberId = memberId;
        ProjectId = projectId;
        RoleId = roleId;
    }
}