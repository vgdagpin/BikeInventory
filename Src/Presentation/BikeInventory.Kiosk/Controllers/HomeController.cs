using BikeInventory.Kiosk.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace BikeInventory.Kiosk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole(Constants.UserRoles.Admin))
            {
                return Redirect("/Home/AdminHome");
            }
            else if (User.IsInRole(Constants.UserRoles.Staff))
            {
                return Redirect("/Home/StaffHome");
            }

            return View();
        }

        [Authorize(Policy = Constants.Policy.Staff)]
        public IActionResult StaffHome()
        {
            return View();
        }

        [Authorize(Policy = Constants.Policy.Administrator)]
        public IActionResult AdminHome()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}