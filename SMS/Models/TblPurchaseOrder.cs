using System;
using System.Collections.Generic;

namespace SMS.Models
{
    public partial class TblPurchaseOrder
    {
        public int Oid { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string ItemName { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Status { get; set; }
        public int? CrId { get; set; }
        public int? Vid { get; set; }

        public virtual TblCustomerRegistration Cr { get; set; }
        public virtual TblVendor V { get; set; }
    }
}
