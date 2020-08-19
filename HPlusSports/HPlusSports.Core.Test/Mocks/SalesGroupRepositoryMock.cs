using HPlusSports.DAL;
using HPlusSports.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSports.Core.Test.Mocks
{
    class SalesGroupRepositoryMock : ITrackingRepository<SalesGroup>
    {
        List<SalesGroup> notADatabase = new List<SalesGroup>();

        public void Add(SalesGroup Item)
        {
            notADatabase.Add(Item);
        }

        public void AddAll(IEnumerable<SalesGroup> Items)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int PrimaryKey)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SalesGroup> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesGroup>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SalesGroup> GetByID(int Id)
        {
            return Task.FromResult(notADatabase.Find(s => s.Id == Id));
        }

        public void Save(SalesGroup Item)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<SalesGroup> Items)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
