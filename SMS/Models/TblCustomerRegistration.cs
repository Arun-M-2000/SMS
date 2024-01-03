using System;
using System.Collections.Generic;

namespace SMS.Models
{
    public partial class TblCustomerRegistration
    {
        public TblCustomerRegistration()
        {
            TblPurchaseOrder = new HashSet<TblPurchaseOrder>();
        }

        public int CrId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? Lid { get; set; }

        public virtual TblLogin L { get; set; }
        public virtual ICollection<TblPurchaseOrder> TblPurchaseOrder { get; set; }
    }
}
