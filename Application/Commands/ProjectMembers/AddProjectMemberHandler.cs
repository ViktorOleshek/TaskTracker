using Domain.Abstraction.Repositories;
using Domain.Entities;
using MediatR;
using FluentResults;
using Domain.DTOs;

namespace Application.Commands.ProjectMembers;

public class AddProjectMemberHandler : IRequestHandler<AddProjectMemberCommand, Result<ProjectMemberDto>>
{
    private readonly IProjectMemberRepository _projectMemberRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IProjectRepository _projectRepository;

    public AddProjectMemberHandler(
        IProjectMemberRepository projectMemberRepository,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IProjectRepository projectRepository)
    {
        _projectMemberRepository = projectMemberRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _projectRepository = projectRepository;
    }

    public async Task<Result<ProjectMemberDto>> Handle(AddProjectMemberCommand request, CancellationToken cancellationToken)
    {
        User? existingUser = await _userRepository.GetByIdAsync(request.UserId);
        if (existingUser is null)
        {
            return Result.Fail<ProjectMemberDto>("User with this id does not exist");
        }

        Project? existingProject = await _projectRepository.GetByIdAsync(request.ProjectId);
        if (existingProject is null)
        {
            return Result.Fail<ProjectMemberDto>("Project with this id does not exist");
        }

        Role? existingRole = await _roleRepository.GetByIdAsync(request.RoleId);
        if (existingRole is null)
        {
            return Result.Fail<ProjectMemberDto>("Role with this id does not exist");
        }

        ProjectMember projectMember = new()
        {
            UserId = request.UserId,
            ProjectId = request.ProjectId,
            RoleId = request.RoleId,
        };

        await _projectMemberRepository.CreateAsync(projectMember);

        ProjectMemberDto projectMemberDto = new()
        {
            UserId = request.UserId,
            UserName = existingUser.Login,
            RoleId = request.RoleId,
            RoleName = existingRole.Name,
        };

        return Result.Ok<ProjectMemberDto>(projectMemberDto);
    }
}