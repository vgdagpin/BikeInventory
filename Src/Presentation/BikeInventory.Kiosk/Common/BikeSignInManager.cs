using System.Security.Claims;

using BikeInventory.Application.Common.Interfaces;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BikeInventory.Kiosk.Common
{
    public class BikeSignInManager : SignInManager<BikeIdentityUser>
    {
        private readonly IPasswordHasher p_BikePasswordHasher;

        public BikeSignInManager(UserManager<BikeIdentityUser> userManager, 
            IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<BikeIdentityUser> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<SignInManager<BikeIdentityUser>> logger, 
            IAuthenticationSchemeProvider schemes, 
            IUserConfirmation<BikeIdentityUser> confirmation,
            IPasswordHasher bikePasswordHasher) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
            p_BikePasswordHasher = bikePasswordHasher;
        }

        public async override Task<SignInResult> PasswordSignInAsync(BikeIdentityUser user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var salt = Convert.FromBase64String(user.Salt);
            var passwordHash = Convert.FromBase64String(user.PasswordHash);

            if (p_BikePasswordHasher.IsPasswordVerified(salt, passwordHash, password))
            {
                return SignInResult.Success;
            }            

            return SignInResult.Failed;
        }

        public override bool IsSignedIn(ClaimsPrincipal principal)
        {
            var a = Context.User.FindFirstValue(ClaimTypes.Name);

            return a != null;
        }
    }
}
