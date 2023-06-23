using ApiUsers.Data.Dtos;
using ApiUsers.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiUsers.Service;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager,
        TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task Register(CreateUserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);

        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
            throw new ApplicationException("Fail to register user.");
    }

    public async Task<string> Login(LoginUserDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);

        if (!result.Succeeded)
        {
            throw new ApplicationException("User not authenticated.");
        }

        var user = _signInManager.UserManager.Users.FirstOrDefault(user =>
            user.NormalizedUserName == loginDto.Username.ToUpper());
        
        var token = _tokenService.GenerateToken(user);

        return token;
    }
}