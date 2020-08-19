using System;
using System.Collections.Generic;

namespace HPlusSports.Models
{
    public partial class PerishableProduct : Product
    {     
        public int? ExpirationDays { get; set; }
        public bool? Refrigerated { get; set; }

    }
}
