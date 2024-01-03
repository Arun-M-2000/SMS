using System;

namespace SMS.ViewModel
{
    public class CusPurVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string ItemName { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Status { get; set; }

    }
}
