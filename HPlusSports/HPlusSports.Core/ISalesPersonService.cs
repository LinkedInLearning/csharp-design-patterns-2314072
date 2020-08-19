using HPlusSports.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPlusSports.Core
{
    public interface ISalesPersonService
    {
        Task MoveSalesPersonToGroup(int salesPersonId, int groupId);
        Task UpdateSalesPersonContact(Salesperson person);
    }
}