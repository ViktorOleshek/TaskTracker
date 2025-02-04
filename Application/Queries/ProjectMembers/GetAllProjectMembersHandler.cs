using Domain.Abstraction.Repositories;
using Domain.DTOs;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Queries.ProjectMembers;
public class GetAllProjectMembersHandler : IRequestHandler<GetAllProjectMembersQuery, Result<IEnumerable<ProjectMemberDto>>>
{
    private readonly IProjectMemberRepository _projectMemberRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public GetAllProjectMembersHandler(IProjectMemberRepository projectMemberRepository, IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _projectMemberRepository = projectMemberRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<Result<IEnumerable<ProjectMemberDto>>> Handle(GetAllProjectMembersQuery request, CancellationToken cancellationToken)
    {
        var projectMembers = await _projectMemberRepository.GetAllByProjectIdAsync(request.ProjectId);
        if (projectMembers == null || !projectMembers.Any())
        {
            return Result.Fail<IEnumerable<ProjectMemberDto>>("No members found in the project.");
        }

        var projectMemberDtos = new List<ProjectMemberDto>();

        foreach (var member in projectMembers)
        {
            User? user = await _userRepository.GetByIdAsync(member.UserId);
            if (user == null)
            {
                continue;
            }

            Role? role = await _roleRepository.GetByIdAsync(member.RoleId);
            if (role == null)
            {
                continue;
            }

            projectMemberDtos.Add(new ProjectMemberDto
            {
                UserId = user.Id,
                UserName = user.Login,
                RoleId = role.Id,
                RoleName = role.Name
            });
        }

        return Result.Ok(projectMemberDtos.AsEnumerable());
    }
}
