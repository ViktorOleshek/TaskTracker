using FluentResults;
using MediatR;

namespace Application.Commands.ProjectMembers;

public class RemoveProjectMemberCommand : IRequest<Result<bool>>
{
    public Guid MemberId { get; }
    public Guid ProjectId { get; }

    public RemoveProjectMemberCommand(Guid memberId, Guid projectId)
    {
        MemberId = memberId;
        ProjectId = projectId;
    }
}
