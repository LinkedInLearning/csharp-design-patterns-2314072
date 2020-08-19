using HPlusSports.DAL;
using HPlusSports.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSports.Core
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepo;
        HPlusSportsContext _context;

        public OrderService(IOrderRepository orderRepo, HPlusSportsContext context)
        {
            _orderRepo = orderRepo;
            _context = context;
        }

        public async Task<IList<Order>> GetCustomerOrders(int CustomerId)
        {
            return await _context.Set<Order>()
                .AsNoTracking()
                .Include(o => o.Customer)
                .Where(o => o.CustomerId == CustomerId)
                .ToListAsync();
        }

        public async Task<IList<Order>> GetOrdersWithCustomers()
        {
            return await _context.Set<Order>()
                .AsNoTracking()
                .Include(o => o.Customer)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<Order> CreateOrder(int customerId, int salesPersonId, List<Tuple<string, int>> productsQuantities)
        {
            var order = _orderRepo.Create(new NewOrderInformation()
            {
                CustomerId = customerId,
                SalesPersonId = salesPersonId,
                products = productsQuantities.Select(p =>
                {
                    return new ProductOrderInformation()
                    {
                        ProductCode = p.Item1,
                        Quantity = p.Item2,
                        Price = GetPriceWithDiscounts(p.Item1, p.Item2)
                    };
                }).ToList()
            });

            await _context.SaveChangesAsync();
            return order;
        }

        private decimal GetPriceWithDiscounts(string productCode, int quantity)
        {
            var product = _context.Set<Product>().First(p => p.ProductCode == productCode);
            if (product.Price > 10 && quantity > 100)
                return (product.Price ?? 1) * 0.95m;
            else
                return product.Price ?? 1;

        }
    }
}
