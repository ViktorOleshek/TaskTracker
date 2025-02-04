using Domain.DTOs;
using FluentResults;
using MediatR;

namespace Application.Queries.ProjectMembers;

public class GetProjectMemberQuery : IRequest<Result<ProjectMemberDto>>
{
    public Guid MemberId { get; }
    public Guid ProjectId { get; }

    public GetProjectMemberQuery(Guid memberId, Guid projectId)
    {
        MemberId = memberId;
        ProjectId = projectId;
    }
}
