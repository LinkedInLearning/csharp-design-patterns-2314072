using System.Collections.Generic;
using HPlusSports.Core;
using HPlusSports.Models;

namespace HPlusSports.Web.ViewModels
{
    public class OrderItemViewModel : Order, IOrderItemViewModel
    {
        public OrderItemViewModel(IEnumerable<Order> orders, Order o)
        {
            base.CreatedDate = o.CreatedDate;
            base.Customer = o.Customer;
            base.CustomerId = o.CustomerId;
            base.Deleted = o.Deleted;
            base.Id = o.Id;
            base.OrderDate = o.OrderDate;
            base.OrderItem = o.OrderItem;
            base.Salesperson = o.Salesperson;
            base.SalespersonId = o.SalespersonId;
            base.Status = o.Status;
            base.TotalDue = o.TotalDue;

            PreviousOrderDates = string.Join("\n",
                        orders.FilterdSelect(
                            o => o.CustomerId == CustomerId
                            && o.OrderDate < base.OrderDate
                            , o => o.OrderDate.ToString("d")
                        ));
        }

        public string CustomerName => Customer.FirstName + " " + Customer.LastName;
        public new string TotalDue => base.TotalDue?.ToString("f2");
        public new string OrderDate => base.OrderDate.ToString("d");
        public string PreviousOrderDates { get; private set; }
    }

    public interface IOrderItemViewModel
    {
        int CustomerId { get; }
        string CustomerName { get; }
        string Status { get; }
        string TotalDue { get; }
        string OrderDate { get; }
        string PreviousOrderDates { get; }
    }
}