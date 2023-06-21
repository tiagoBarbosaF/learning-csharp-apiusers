using ApiUsers.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiUsers.Data;

public class UserDbContext : IdentityDbContext<User>
{
    public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts)
    {
        
    }
}