using HPlusSports.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HPlusSports.DAL
{
    /// <summary>
    /// This is a repository and UOW on top of entity framework.
    /// It takes away a lot of the flexibility of entity framework, 
    /// but hides the soft delete in the database from the code, which may be desirable.
    /// This pattern makes more sense if there are other db fields of a tracking nature 
    /// like last updated time and user on a lot of different entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TrackingRepository<T> : ITrackingRepository<T> where T : TrackedEntity
    {
        protected HPlusSportsContext _context;
        public TrackingRepository(HPlusSportsContext context)
        {
            _context = context;
        }

        public virtual void Add(T Item)
        {
            _context.Add(Item);
        }

        public virtual void AddAll(IEnumerable<T> Items)
        {
            _context.AddRange(Items);
        }

        public virtual async Task Delete(int Id)
        {
            var item = await GetByID(Id);
            item.Deleted = true;
        }

        public virtual IQueryable<T> Get()
        {
            return _context.Set<T>().Where(e => !e.Deleted);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().Where(e => !e.Deleted).ToListAsync();
        }

        public virtual async Task<T> GetByID(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public virtual void Save(T Item)
        {
            _context.Update(Item);
        }

        public virtual void SaveAll(IEnumerable<T> Items)
        {
            _context.UpdateRange(Items);
        }

        public virtual Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}