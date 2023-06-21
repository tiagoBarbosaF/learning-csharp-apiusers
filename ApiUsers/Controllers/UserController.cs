using ApiUsers.Data.Dtos;
using ApiUsers.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsers.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private RegisterService _registerService;

    public UserController(RegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost]
    public async Task<IActionResult> PutUser(CreateUserDto userDto)
    {
        await _registerService.Register(userDto);
        
        return Ok("User registered.");
    }
}