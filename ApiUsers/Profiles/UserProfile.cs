using ApiUsers.Data.Dtos;
using ApiUsers.Models;
using AutoMapper;

namespace ApiUsers.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}