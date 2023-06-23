using ApiUsers.Data.Dtos;
using ApiUsers.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsers.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> PutUser(CreateUserDto userDto)
    {
        await _userService.Register(userDto);

        return Ok("User registered.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto loginDto)
    {
        var token = await _userService.Login(loginDto);

        return Ok($"token: {token}");
    }
}