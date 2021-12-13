using System.Security.Claims;
using System.Text.Json;

using BikeInventory.Models;

namespace BikeInventory.Kiosk
{
    public static class ClaimsPrincipalExtensions
    {
        public static User GetUserData(this ClaimsPrincipal principal)
        {
            var claim = principal.FindFirst(ClaimTypes.UserData);

            if (claim == null)
            {
                return null;
            }

            var userDataJson = claim.Value;

            if (string.IsNullOrWhiteSpace(userDataJson))
            {
                return null;
            }

            return JsonSerializer.Deserialize<User>(userDataJson);
        }
    }
}
