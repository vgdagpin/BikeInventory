namespace BikeInventory.Kiosk.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }
}
