using System.Security.Claims;
using System.Text.Json;

using AutoMapper;

using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BikeInventory.Kiosk.Common
{
    public class BikeUserClaimsPrincipalFactory : IUserClaimsPrincipalFactory<IdentityUser>
    {
        private readonly IBikeInventoryDbContext p_DbContext;
        private readonly IMapper p_Mapper;

        public BikeUserClaimsPrincipalFactory(IBikeInventoryDbContext dbContext, IMapper mapper)
        {
            p_DbContext = dbContext;
            p_Mapper = mapper;
        }

        public async Task<ClaimsPrincipal> CreateAsync(IdentityUser user)
        {
            var userData = await p_DbContext.Users
                .Include(a => a.N_UserRoles)
                .Include(a => a.N_UserCredential)
                .SingleAsync(a => a.N_UserCredential.Username == user.UserName);

            var mUserData = p_Mapper.Map<User>(userData);

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.UserData, JsonSerializer.Serialize(mUserData))
            }, Constants.IdentityConstants.ApplicationScheme);

            foreach (var role in mUserData.Roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return new ClaimsPrincipal(identity);
        }
    }
}
