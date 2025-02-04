using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
public class IdentityController : ControllerBase
{
    //[Authorize(Roles = "Admin")]
    //[HttpPost("admin-action")]
    //public IActionResult AdminAction()
    //{
    //    return Ok("Only Admin can access this.");
    //}

    //[Authorize(Roles = "User")]
    //[HttpPost("user-action")]
    //public IActionResult UserAction()
    //{
    //    return Ok("Only User can access this.");
    //}
}