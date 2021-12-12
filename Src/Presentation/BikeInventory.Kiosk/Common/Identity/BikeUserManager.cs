using System.Security.Claims;

using BikeInventory.Application.Common.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BikeInventory.Kiosk.Common
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/main/src/Identity/Extensions.Core/src/UserManager.cs
    /// </summary>
    public class BikeUserManager : UserManager<IdentityUser>
    {
        private readonly IPasswordHasher p_BikePasswordHasher;

        public BikeUserManager(IUserStore<IdentityUser> store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<IdentityUser> passwordHasher, 
            IEnumerable<IUserValidator<IdentityUser>> userValidators, 
            IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<IdentityUser>> logger,
            IPasswordHasher bikePasswordHasher) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            p_BikePasswordHasher = bikePasswordHasher;
        }

        public override Task<IdentityUser> GetUserAsync(ClaimsPrincipal principal)
        {
            var username = principal.FindFirstValue(Options.ClaimsIdentity.UserNameClaimType);

            return Store.FindByNameAsync(username, default);
        }

        public override Task<bool> CheckPasswordAsync(IdentityUser user, string password)
        {
            var salt = Convert.FromBase64String(user.SecurityStamp);
            var passwordHash = Convert.FromBase64String(user.PasswordHash);
            var isVerified = p_BikePasswordHasher.IsPasswordVerified(salt, passwordHash, password);

            return Task.FromResult(isVerified);
        }
    }
}
