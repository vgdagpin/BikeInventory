using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_UserRole
    {
        public int UserID { get; set; }
        public string Role { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime? ExpireOn { get; set; }
    }
}