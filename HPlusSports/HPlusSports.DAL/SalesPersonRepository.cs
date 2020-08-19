using HPlusSports.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HPlusSports.DAL
{
    /// <summary>
    /// This extends the Tracking repository, but adds a layer of methods for shared 
    /// queries or actions that are "beneath" the service layer/business logic (aka Data Logic)
    /// </summary>
    public class SalesPersonRepository : TrackingRepository<Salesperson>, ISalesPersonRepository
    {
        public SalesPersonRepository(HPlusSportsContext context) : base(context) { }

        public Task<List<Salesperson>> GetSalesPeopleByStateGroup(string state)
        {
            return _context.Set<Salesperson>().Where(s => s.SalesGroup.State == state).ToListAsync();
        }

        public Task<List<Salesperson>> GetWithOrders()
        {
            return _context.Set<Salesperson>().Include(s => s.Order).ToListAsync();
        }
    }
}
