using System.Security.Claims;

using BikeInventory.Application.Common.Interfaces;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BikeInventory.Kiosk.Common
{
    public class BikeSignInManager : SignInManager<IdentityUser>
    {
        public BikeSignInManager(UserManager<IdentityUser> userManager, 
            IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<IdentityUser> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<SignInManager<IdentityUser>> logger, 
            IAuthenticationSchemeProvider schemes, 
            IUserConfirmation<IdentityUser> confirmation) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }

        public override bool IsSignedIn(ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            return principal.Identities != null &&
                principal.Identities.Any(i => i.AuthenticationType == Constants.IdentityConstants.ApplicationScheme);
        }
    }
}
