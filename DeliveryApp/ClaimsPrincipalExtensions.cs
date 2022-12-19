using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DeliveryApp
{
    public static class ClaimsPrincipalExtensions
    {
        [Authorize]
        public static string GetUserId(this ClaimsPrincipal user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user?.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
