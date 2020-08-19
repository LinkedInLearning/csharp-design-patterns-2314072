using HPlusSports.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using HPlusSports.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSports.Core.Test.Mocks
{
    class SalesPersonRepositoryMock : ISalesPersonRepository
    {
        List<Salesperson> notADatabase = new List<Salesperson>();
        public void Add(Salesperson Item)
        {
            notADatabase.Add(Item);
        }

        public void AddAll(IEnumerable<Salesperson> Items)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int PrimaryKey)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Salesperson> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<Salesperson>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Salesperson> GetByID(int Id)
        {
            return Task.FromResult(notADatabase.Find(s => s.Id == Id));
        }

        public Task<List<Salesperson>> GetSalesPeopleByStateGroup(string state)
        {
            throw new NotImplementedException();
        }

        public Task<List<Salesperson>> GetWithOrders()
        {
            throw new NotImplementedException();
        }

        public void Save(Salesperson Item)
        {
            notADatabase.Remove(notADatabase.Find(s => s.Id == Item.Id));
            notADatabase.Add(Item);
        }

        public void SaveAll(IEnumerable<Salesperson> Items)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            return Task.CompletedTask;
        }
    }
}
