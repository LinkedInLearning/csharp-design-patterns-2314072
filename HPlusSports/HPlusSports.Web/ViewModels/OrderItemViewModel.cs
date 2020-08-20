using System.Collections.Generic;
using HPlusSports.Core;
using HPlusSports.Models;

namespace HPlusSports.Web.ViewModels{
    public class OrderItemViewModel {
        private Order order;

        public OrderItemViewModel (IEnumerable<Order> orders, Order adaptee)
        {
            order = adaptee;
            PreviousOrderDates = string.Join("\n",  
                        orders.FilterdSelect(
                            o => o.CustomerId == order.CustomerId 
                            && o.OrderDate < order.OrderDate 
                            , o => o.OrderDate.ToString("d") 
                        ));
        }
        
        public int CustomerId => order.CustomerId;
        public string CustomerName => order.Customer.FirstName + " " + 
            order.Customer.LastName;

        public string TotalDue => order.TotalDue?.ToString("f2");

        public string Status => order.Status;

        public string OrderDate => order.OrderDate.ToString("d");

        public string PreviousOrderDates {get; private set;}
    }
}