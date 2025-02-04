using Domain.Abstraction.Repositories;
using Domain.DTOs;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Queries.ProjectMembers;

public class GetProjectMemberHandler : IRequestHandler<GetProjectMemberQuery, Result<ProjectMemberDto>>
{
    private readonly IProjectMemberRepository _projectMemberRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public GetProjectMemberHandler(IProjectMemberRepository projectMemberRepository, IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _projectMemberRepository = projectMemberRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<Result<ProjectMemberDto>> Handle(GetProjectMemberQuery request, CancellationToken cancellationToken)
    {
        ProjectMember? projectMember = await _projectMemberRepository.GetAsync(request.MemberId, request.ProjectId);
        if (projectMember == null)
        {
            return Result.Fail("Project member not found");
        }

        User? user = await _userRepository.GetByIdAsync(request.MemberId);
        if (user == null)
        {
            return Result.Fail("User not found");
        }

        Role? role = await _roleRepository.GetByIdAsync(projectMember.RoleId);
        if (role == null)
        {
            return Result.Fail("Role not found");
        }

        var projectMemberDto = new ProjectMemberDto
        {
            UserId = user.Id,
            UserName = user.Login,
            RoleId = role.Id,
            RoleName = role.Name
        };

        return Result.Ok(projectMemberDto);
    }
}
