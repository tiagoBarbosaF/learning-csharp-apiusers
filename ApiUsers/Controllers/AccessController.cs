using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsers.Controllers;

[ApiController]
[Route("[controller]")]
public class AccessController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "MinimalAge")]
    public IActionResult GetAccess()
    {
        return Ok("Access granted.");
    }
}