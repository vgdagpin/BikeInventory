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
            var rentalTransaction = p_RentalTransactionRepository.Find(transactionID);

            var model = new Checkin
            {
                Ticket = rentalTransaction,
                PaymentHandlers = p_PaymentRepository.GetPaymentHandlers()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Payment(Bike data)
        {
            //var bike = p_BikeRepository.Find(data.ID);

            //if (bike == null)
            //    return NotFound();

            //if (bike.Status != Enums.BikeStatus.Available)
            //{
            //    return NotFound();
            //}

            //if (!p_RentalTransactionRepository.TryCheckOutBike(bike, User.GetUserData(), out CheckoutResult checkoutResult))
            //{
            //    var failedCheckout = checkoutResult as FailedCheckoutResult;

            //    return NotFound();
            //}

            //var paymentViewModel = new PaymentViewModel
            //{
            //    PaymentHandlers = p_PaymentRepository.GetPaymentHandlers(),
            //    Bike = bike,
            //    Ticket = (checkoutResult as SuccessCheckoutResult).Ticket
            //};

            //return View(paymentViewModel);
            throw new NotImplementedException();
        }

        public IActionResult Receipt(Payment payment)
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