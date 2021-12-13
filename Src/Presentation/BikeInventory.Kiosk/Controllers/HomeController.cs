using BikeInventory.Common;
using BikeInventory.Interfaces;
using BikeInventory.Kiosk.Models;
using BikeInventory.Kiosk.Views.Home;
using BikeInventory.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace BikeInventory.Kiosk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> p_Logger;
        private readonly IBikeModelRepository p_BikeModelRepository;
        private readonly IBikeRepository p_BikeRepository;
        private readonly IPaymentRepository p_PaymentRepository;
        private readonly IRentalTransactionRepository p_RentalTransactionRepository;
        private readonly ICustomerRepository p_CustomerRepository;

        public HomeController
            (
                ILogger<HomeController> logger, 
                IBikeModelRepository bikeModelRepository, 
                IBikeRepository bikeRepository, 
                IPaymentRepository paymentRepository,
                IRentalTransactionRepository rentalTransactionRepository,
                ICustomerRepository customerRepository
            )
        {
            p_Logger = logger;
            p_BikeModelRepository = bikeModelRepository;
            p_BikeRepository = bikeRepository;
            p_PaymentRepository = paymentRepository;
            p_RentalTransactionRepository = rentalTransactionRepository;
            p_CustomerRepository = customerRepository;
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
            var model = new StaffHome
            {
                BikeModels = p_BikeModelRepository.Get().ToList(),
                Customers = p_CustomerRepository.Get().ToList()
            };

            return View(model);
        }

        [Authorize(Policy = Constants.Policy.Administrator)]
        public IActionResult AdminHome()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(CheckoutPayload data)
        {
            var bike = p_BikeRepository.Find(data.BikeID);
            var customer = p_CustomerRepository.Find(data.CustomerID);

            Guard.ThrowIfNull(bike, nameof(bike));
            Guard.ThrowIfNull(customer, nameof(customer));


            p_RentalTransactionRepository.TryCheckOutBike(bike.ID, User.GetUserData().ID, customer.ID, out CheckoutResult checkoutResult);

            var model = new Checkout
            {
                Bike = bike,
                CheckoutResult = checkoutResult
            };

            return View(model);
        }

        [HttpGet("/Home/Checkin/{transactionID}")]
        public IActionResult Checkin(Guid transactionID)
        {
            p_RentalTransactionRepository.TryCheckInBike(transactionID, User.GetUserData().ID, out CheckinResult checkinResult);

            var model = new Checkin
            {
                PaymentHandlers = p_PaymentRepository.GetPaymentHandlers(),
                CheckinResult = checkinResult
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentPayload payload)
        {
            var paymentResult =  await p_PaymentRepository.ProcessPayment(payload.PaymentHandlerID, payload.TransactionID);

            return View(new PaymentViewModel
            {
                PaymentResult = paymentResult
            });
        }

        public IActionResult Receipt(Payment payment)
        {
            p_RentalTransactionRepository.ProcessCheckInBike(payment.TransactionID);

            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}