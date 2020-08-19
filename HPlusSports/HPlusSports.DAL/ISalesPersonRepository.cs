using System.Collections.Generic;
using System.Threading.Tasks;
using HPlusSports.Models;

namespace HPlusSports.DAL
{
    public interface ISalesPersonRepository : ITrackingRepository<Salesperson>
    {
        Task<List<Salesperson>> GetSalesPeopleByStateGroup(string state);
        Task<List<Salesperson>> GetWithOrders();
    }
}