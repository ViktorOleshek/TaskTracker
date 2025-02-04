using Application.Commands.ProjectMembers;
using Application.Queries.ProjectMembers;
using Domain.Constants;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Filters;

namespace WebApi.Controllers;

[Authorize]
[Route("projects/{projectId:guid}/members")]
public class ProjectMemberController : ControllerBase
{
    private Guid UserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

    private readonly ISender _sender;

    public ProjectMemberController(ISender sender)
    {
        _sender = sender;
    }

    [ProjectMember(Roles.Admin)]
    [HttpPost]
    public async Task<IActionResult> AddMember([FromRoute] Guid projectId, [FromBody] ProjectMemberRequest request)
    {
        var command = new AddProjectMemberCommand(request.UserId, projectId, request.RoleId);
        var result = await _sender.Send(command);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMembers([FromRoute] Guid projectId)
    {
        var query = new GetAllProjectMembersQuery(projectId);
        var result = await _sender.Send(query);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Value);
    }

    [ProjectMember]
    [HttpGet("{memberId:guid}")]
    public async Task<IActionResult> GetMember([FromRoute] Guid projectId, [FromRoute] Guid memberId)
    {
        var query = new GetProjectMemberQuery(memberId, projectId);
        var result = await _sender.Send(query);

        if (result.IsFailed)
        {
            return NotFound(result.Errors);
        }

        return Ok(result.Value);
    }

    [ProjectMember(Roles.Admin)]
    [HttpPut("{memberId:guid}/role")]
    public async Task<IActionResult> UpdateMemberRole([FromRoute] Guid projectId, [FromRoute] Guid memberId, [FromBody] Guid roleId)
    {
        var command = new UpdateProjectMemberRoleCommand(memberId, projectId, roleId);
        var result = await _sender.Send(command);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Value);
    }

    [ProjectMember(Roles.Admin)]
    [HttpDelete("{memberId:guid}")]
    public async Task<IActionResult> RemoveMember([FromRoute] Guid projectId, [FromRoute] Guid memberId)
    {
        var command = new RemoveProjectMemberCommand(memberId, projectId);
        var result = await _sender.Send(command);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return NoContent();
    }
}
