using lkPangilinan.RetailApp.Windows.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lkPangilinan.RetailApp.Windows.Models
{
    public class Order
    {
        public Guid? Id { get; set; }

        public Guid? CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public string BillingAddress { get; set; }

        public string Default_ShippingAddress { get; set; }

        public string Customer_EmailAddress { get; set; }

        public DateTime DateTime { get; set; }

        public Status Status { get; set; }
    }
}
