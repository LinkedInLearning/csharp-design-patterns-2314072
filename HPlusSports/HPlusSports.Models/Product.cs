using System;
using System.Collections.Generic;

namespace HPlusSports.Models
{
    public partial class Product : TrackedEntity
    {
        public Product()
        {
           
        }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? Size { get; set; }
        public string Variety { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }

        
    }
}
