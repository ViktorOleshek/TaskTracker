using Domain.DTOs;
using FluentResults;
using MediatR;

namespace Application.Queries.ProjectMembers;

public class GetAllProjectMembersQuery : IRequest<Result<IEnumerable<ProjectMemberDto>>>
{
    public Guid ProjectId { get; }

    public GetAllProjectMembersQuery(Guid projectId)
    {
        ProjectId = projectId;
    }
}