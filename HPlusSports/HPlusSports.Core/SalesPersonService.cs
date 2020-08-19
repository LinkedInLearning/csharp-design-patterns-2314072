using HPlusSports.DAL;
using HPlusSports.Models;
using System.Threading.Tasks;

namespace HPlusSports.Core
{
    public class SalesPersonService : ISalesPersonService
    {
        ISalesPersonRepository _salesRepo;
        ITrackingRepository<SalesGroup> _salesGroupRepo;

        public SalesPersonService(ISalesPersonRepository salesPersonRepository, ITrackingRepository<SalesGroup> salesGroupRepo)
        {
            _salesRepo = salesPersonRepository;
            _salesGroupRepo = salesGroupRepo;
        }

        public async Task MoveSalesPersonToGroup(int salesPersonId, int groupId)
        {
            var person = await _salesRepo.GetByID(salesPersonId);
            var group = await _salesGroupRepo.GetByID(groupId);
            person.SalesGroup = group;
            _salesRepo.Save(person);
            await _salesRepo.SaveChanges();
        }

        public async Task UpdateSalesPersonContact(Salesperson person)
        {
            var existingSalesperson = await _salesRepo.GetByID(person.Id);

            existingSalesperson.FirstName = person.FirstName;
            existingSalesperson.LastName = person.LastName;
            existingSalesperson.Email = person.Email;
            existingSalesperson.Phone = person.Phone;

            _salesRepo.Save(existingSalesperson);
            await _salesRepo.SaveChanges();
        }

    }
}
