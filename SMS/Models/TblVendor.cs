using System;
using System.Collections.Generic;

namespace SMS.Models
{
    public partial class TblVendor
    {
        public TblVendor()
        {
            TblPurchaseOrder = new HashSet<TblPurchaseOrder>();
        }

        public int Vid { get; set; }
        public string VendorName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<TblPurchaseOrder> TblPurchaseOrder { get; set; }
    }
}
