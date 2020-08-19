using HPlusSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HPlusSports.DAL
{
    public interface ITrackingRepository<T> where T : TrackedEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetByID(int Id);
        IQueryable<T> Get();
        void Save(T Item);
        void Add(T Item);
        void SaveAll(IEnumerable<T> Items);
        void AddAll(IEnumerable<T> Items);
        Task Delete(int PrimaryKey);

        Task SaveChanges();

    }
}
