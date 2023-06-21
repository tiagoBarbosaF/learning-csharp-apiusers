using Microsoft.AspNetCore.Identity;

namespace ApiUsers.Models;

public class User : IdentityUser
{
    public DateTime Birthdate { get; set; }

    public User() : base()
    {
    }
}