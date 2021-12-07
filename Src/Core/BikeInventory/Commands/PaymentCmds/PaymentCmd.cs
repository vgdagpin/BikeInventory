using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Models;

using TasqR;

namespace BikeInventory.Commands.PaymentCmds
{
    public class PaymentCmd : ITasq<PaymentResult>
    {
        public PaymentCmd(Guid transactionID)
        {
            TransactionID = transactionID;
        }

        public Guid TransactionID { get; }
    }
}
