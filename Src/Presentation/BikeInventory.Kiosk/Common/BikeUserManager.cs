using System.Security.Claims;

using BikeInventory.Application.Common.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BikeInventory.Kiosk.Common
{
    public class BikeUserManager : UserManager<BikeIdentityUser>
    {
        public BikeUserManager(IUserStore<BikeIdentityUser> store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<BikeIdentityUser> passwordHasher, 
            IEnumerable<IUserValidator<BikeIdentityUser>> userValidators, 
            IEnumerable<IPasswordValidator<BikeIdentityUser>> passwordValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<BikeIdentityUser>> logger) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }

        public override Task<BikeIdentityUser> GetUserAsync(ClaimsPrincipal principal)
        {
            var username = principal.FindFirstValue(Options.ClaimsIdentity.UserNameClaimType);

            return Store.FindByNameAsync(username, default);
        }
    }
}
