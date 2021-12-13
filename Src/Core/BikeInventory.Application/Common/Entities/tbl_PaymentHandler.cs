using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_PaymentHandler
    {
        public short ID { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public bool IsActive { get; set; }


        public string TaskAssembly { get; set; }
        public string TaskClass { get; set; }
        public string HandlerAssembly { get; set; }
        public string HandlerClass { get; set; }
    }
}
