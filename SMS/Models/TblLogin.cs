using System;
using System.Collections.Generic;

namespace SMS.Models
{
    public partial class TblLogin
    {
        public TblLogin()
        {
            TblCustomerRegistration = new HashSet<TblCustomerRegistration>();
        }

        public int Lid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TblCustomerRegistration> TblCustomerRegistration { get; set; }
    }
}
