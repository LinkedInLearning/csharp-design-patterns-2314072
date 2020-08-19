using HPlusSports.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPlusSports.DAL
{
    /// <summary>
    /// This repository is meant to augment the use of the ef context directly.
    /// Simple operations can use the context as unit of work, and the set as the repo
    /// but complex actions and queries can be added here.  
    /// Data level actions like creating the entity relations "OrderItem" 
    /// can happen without muddying the logic in the Data Layer 
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        protected HPlusSportsContext _context;
        public OrderRepository(HPlusSportsContext context)
        {
            _context = context;
        }

        public Task<List<Order>> GetByCustomerPartialLastName(string lastName)
        {
            return _context.Set<Order>().Where(o => !o.Deleted).Include(o => o.Customer)
                .Where(o => o.Customer.LastName.ToLowerInvariant().Contains(lastName.ToLowerInvariant()))
                .ToListAsync();
        }

        public Order Create(NewOrderInformation orderInfo)
        {
            var order = new Order()
            {
                CustomerId = orderInfo.CustomerId,
                SalespersonId = orderInfo.SalesPersonId,
                Status = "due",
                TotalDue = orderInfo.products.Sum(p => p.Price * p.Quantity),
                CreatedDate = DateTime.Now,
                OrderDate = DateTime.Now,
                OrderItem = orderInfo.products.Select(p =>
                    {
                        return new OrderItem()
                        {
                            ProductId = p.ProductCode,
                            Quantity = p.Quantity
                        };
                    }).ToList()
                  
            };

            _context.Add(order);

            return order;
        }
    }
}
