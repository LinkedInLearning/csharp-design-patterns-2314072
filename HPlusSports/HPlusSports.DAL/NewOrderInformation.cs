using System;
using System.Collections.Generic;
using System.Text;

namespace HPlusSports.DAL
{
    public class NewOrderInformation
    {
        public int SalesPersonId { get; set; }
        public int CustomerId { get; set; }
        public List<ProductOrderInformation> products { get; set; }
    }

    public class ProductOrderInformation
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
