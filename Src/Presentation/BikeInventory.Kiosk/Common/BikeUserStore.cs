using BikeInventory.Application.Common.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BikeInventory.Kiosk.Common
{
    public class BikeUserStore : IUserStore<BikeIdentityUser>
    {
        private readonly IBikeInventoryDbContext p_DbContext;

        public BikeUserStore(IBikeInventoryDbContext dbContext)
        {
            p_DbContext = dbContext;
        }

        public Task<IdentityResult> CreateAsync(BikeIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(BikeIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public Task<BikeIdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<BikeIdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            BikeIdentityUser user = new BikeIdentityUser();

            var userCred = await p_DbContext.UserCredentials.SingleOrDefaultAsync(a => a.Username == normalizedUserName);

            if (userCred == null) return null;

            user.UserName = normalizedUserName;
            user.PasswordHash = Convert.ToBase64String(userCred.Password);
            user.Salt = Convert.ToBase64String(userCred.Salt);

            return user;
        }

        public Task<string> GetNormalizedUserNameAsync(BikeIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(BikeIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(BikeIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(BikeIdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(BikeIdentityUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(BikeIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
