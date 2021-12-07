using System.Security.Claims;

using Microsoft.AspNetCore.Identity;

namespace BikeInventory.Kiosk.Common
{
    public class BikeUserClaimsPrincipalFactory : IUserClaimsPrincipalFactory<BikeIdentityUser>
    {
        public Task<ClaimsPrincipal> CreateAsync(BikeIdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}
