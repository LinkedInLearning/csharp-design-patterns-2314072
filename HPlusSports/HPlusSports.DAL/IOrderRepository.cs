using System.Collections.Generic;
using System.Threading.Tasks;
using HPlusSports.Models;

namespace HPlusSports.DAL
{
    public interface IOrderRepository
    {
        Order Create(NewOrderInformation orderInfo);
        Task<List<Order>> GetByCustomerPartialLastName(string lastName);
    }
}