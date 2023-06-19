using ApiUsers.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsers.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult PutUser(CreateUserDto userDto)
    {
        throw new NotImplementedException();
    }
}