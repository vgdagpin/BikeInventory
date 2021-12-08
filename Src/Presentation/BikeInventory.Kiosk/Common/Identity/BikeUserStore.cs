using BikeInventory.Application.Common.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BikeInventory.Kiosk.Common
{
    public class BikeUserStore : UserStore<IdentityUser>
    {
        private readonly IBikeInventoryDbContext p_DbContext;

        public BikeUserStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
            p_DbContext = (IBikeInventoryDbContext)context;
        }

        public async override Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default)
        {
            var userCred = await p_DbContext.UserCredentials.SingleOrDefaultAsync(a => a.Username == normalizedUserName);

            if (userCred == null) return null;

            var user = new IdentityUser(normalizedUserName);

            user.UserName = normalizedUserName;
            user.PasswordHash = Convert.ToBase64String(userCred.Password);
            user.SecurityStamp = Convert.ToBase64String(userCred.Salt);

            return user;
        }
    }
}
