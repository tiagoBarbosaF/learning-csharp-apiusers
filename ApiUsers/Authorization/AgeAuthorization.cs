using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ApiUsers.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinimalAge>
{
    private IHttpContextAccessor _httpContext;

    public AgeAuthorization(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimalAge requirement)
    {
        var birthdateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if (birthdateClaim is null)
            return Task.CompletedTask;

        var birthdate = Convert.ToDateTime(birthdateClaim.Value);

        var userAge = DateTime.Today.Year - birthdate.Year;

        if (birthdate > DateTime.Today.AddYears(-userAge)) userAge--;

        if (userAge >= requirement.Age) 
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}