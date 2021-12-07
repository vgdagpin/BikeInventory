using Microsoft.AspNetCore.Identity;

namespace BikeInventory.Kiosk.Common
{
    public class BikeIdentityUser : IdentityUser
    {
        public string Salt { get; set; }
    }
}
