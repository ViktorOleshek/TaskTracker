using Domain.Abstraction.Repositories;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Commands.ProjectMembers;

public class UpdateProjectMemberRoleHandler : IRequestHandler<UpdateProjectMemberRoleCommand, Result<bool>>
{
    private const int NoRowsAffected = 0;
    private readonly IProjectMemberRepository _projectMemberRepository;
    private readonly IRoleRepository _roleRepository;

    public UpdateProjectMemberRoleHandler(
        IProjectMemberRepository projectMemberRepository,
        IRoleRepository roleRepository)
    {
        _projectMemberRepository = projectMemberRepository;
        _roleRepository = roleRepository;
    }

    public async Task<Result<bool>> Handle(UpdateProjectMemberRoleCommand request, CancellationToken cancellationToken)
    {
        Role? role = await _projectMemberRepository
            .GetRoleAsync(request.MemberId, request.ProjectId);
        if (role is null)
        {
            return Result.Fail<bool>("Member not found in the project.");
        }

        Role? existingRole = await _roleRepository.GetByIdAsync(request.RoleId);
        if (existingRole is null)
        {
            return Result.Fail<bool>("Role with this id does not exist.");
        }

        ProjectMember projectMember = new()
        {
            UserId = request.MemberId,
            ProjectId = request.ProjectId,
            RoleId = request.RoleId,
        };

        int rowsAffected = await _projectMemberRepository.UpdateAsync(projectMember);
        if (rowsAffected <= NoRowsAffected)
        {
            return Result.Fail<bool>("Failed to update member role.");
        }

        return Result.Ok(true);
    }
}
