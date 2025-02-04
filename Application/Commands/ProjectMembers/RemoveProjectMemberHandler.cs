using Domain.Abstraction.Repositories;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Commands.ProjectMembers;

public class RemoveProjectMemberHandler : IRequestHandler<RemoveProjectMemberCommand, Result<bool>>
{
    private const int NoRowsAffected = 0;
    private readonly IProjectMemberRepository _projectMemberRepository;

    public RemoveProjectMemberHandler(
        IProjectMemberRepository projectMemberRepository)
    {
        _projectMemberRepository = projectMemberRepository;
    }

    public async Task<Result<bool>> Handle(RemoveProjectMemberCommand request, CancellationToken cancellationToken)
    {
        var role = await _projectMemberRepository
            .GetRoleAsync(request.MemberId, request.ProjectId);
        if (role is null)
        {
            return Result.Fail<bool>("Member not found in the project.");
        }

        ProjectMember projectMember = new()
        {
            UserId = request.MemberId,
            ProjectId = request.ProjectId,
            RoleId = role.Id,
        };

        int rowsAffected = await _projectMemberRepository.DeleteAsync(projectMember);
        if (rowsAffected <= NoRowsAffected)
        {
            return Result.Fail<bool>("Failed to remove the member.");
        }

        return Result.Ok(true);
    }
}
