using ApiUsers.Data.Dtos;
using ApiUsers.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiUsers.Service;

public class RegisterService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public RegisterService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task Register(CreateUserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);

        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
            throw new ApplicationException("Fail to register user.");
    }
}