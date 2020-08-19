using System;
using System.Collections.Generic;

namespace HPlusSports.Models
{
    public partial class Salesperson : TrackedEntity
    {
        public Salesperson()
        {
            Order = new HashSet<Order>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
       
        public string SalesGroupState { get; set; }
        public int SalesGroupType { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        public virtual ICollection<Order> Order { get; set; }

        public virtual SalesGroup SalesGroup { get; set; }

    }
}
