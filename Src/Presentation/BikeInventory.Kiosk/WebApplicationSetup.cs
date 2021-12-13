using System.Globalization;

namespace BikeInventory.Kiosk
{
    public static class WebApplicationSetup
    {
        public static WebApplication Setup(this WebApplication webApp)
        {
            var cultureInfo = new CultureInfo("en-PH");
            cultureInfo.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            return webApp;
        }
    }
}
