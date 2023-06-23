using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiUsers.Models;
using Microsoft.IdentityModel.Tokens;

namespace ApiUsers.Service;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims =
        {
            new("username", user.UserName),
            new("id", user.Id),
            new("birthdate", user.Birthdate.ToString(CultureInfo.CurrentCulture))
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("23489713riu1r089r312r8123uh9r8dfhqiu049"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(15), claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}