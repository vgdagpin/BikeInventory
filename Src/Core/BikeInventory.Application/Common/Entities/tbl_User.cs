using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_User
    {
        public int ID { get; set; }        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public tbl_UserCredential N_UserCredential { get; set; }
        public ICollection<tbl_UserRole> N_UserRoles { get; set; } = new HashSet<tbl_UserRole>();
    }
}

