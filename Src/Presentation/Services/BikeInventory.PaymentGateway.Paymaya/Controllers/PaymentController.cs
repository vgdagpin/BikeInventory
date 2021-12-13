using BikeInventory.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeInventory.PaymentGateway.Paymaya.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly DummyDb p_Db;

        public PaymentController(ILogger<PaymentController> logger, DummyDb db)
        {
            _logger = logger;
            p_Db = db;
        }

        [HttpGet]
        [Route("/Payment")]
        public IEnumerable<string> GetAll()
        {
            return p_Db.Receipts.Select(a => a.Key).ToList();
        }

        [HttpGet]
        [Route("/Payment/{referenceNumber}")]
        public PaymentResult Get(string referenceNumber)
        {
            if (!p_Db.Receipts.ContainsKey(referenceNumber))
            {
                // then handle in pipeline that this will show as 404
                // so that it will not return as success with no content
                return new FailedPaymentResult
                {
                    Error = new Exception("Not Found!")
                };
            }

            return new SuccessPaymentResult
            {
                ReferenceNumber = referenceNumber,
                Receipt = p_Db.Receipts[referenceNumber]
            };
        }

        [HttpPost]
        [Route("/SendPayment")]
        public PaymentResult SendPayment([FromBody] Ticket ticket)
        {
            var retVal = new SuccessPaymentResult
            {
                ServiceName = "Paymaya",
                ReferenceNumber = Guid.NewGuid().ToString("N"),
                Ticket = ticket
            };

            if (p_Db.Receipts.ContainsKey(retVal.ReferenceNumber))
            {
                retVal.Receipt = p_Db.Receipts[retVal.ReferenceNumber];

                return retVal;
            }

            // do payment validations here
            // do transaction            

            retVal.Receipt = p_Db.Receipts[retVal.ReferenceNumber] = new Receipt { TransactionDate = DateTime.Now };

            return retVal;
        }
    }
}
