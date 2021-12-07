using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_PaymentHandlerSetting
    {
        public string Environment { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
    }
}
