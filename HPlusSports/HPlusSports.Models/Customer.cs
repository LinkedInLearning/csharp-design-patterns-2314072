using System;
using System.Collections.Generic;

namespace HPlusSports.Models
{
    public partial class Customer : TrackedEntity
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string customerEmail;
        public string Email
        {
            get { return customerEmail; }
            set { customerEmail = value?.ToLower(); }
        }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
