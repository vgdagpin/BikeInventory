using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_UserCredential
    {
        public int ID { get; set; }

        public string Username { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Password { get; set; }
        public int FailedLoginCount { get; set; }

        public DateTime? ExpiresOn { get; set; }

        public bool IsTemporaryPassword { get; set; }
        public string TemporaryPassword { get; set; }
    }
}
