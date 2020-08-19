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
    /// This Repository Removes Unit of Work from the Repository and forces actions to be 
    /// atomic.  When there are not business reasons to do multiple actions in a single transaction
    /// this allows the business layer to ignore the 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AtomicRepository<T> : IRepository<T> where T : Entity
    {
        protected HPlusSportsContext _context;
        public AtomicRepository(HPlusSportsContext context)
        {
            _context = context;
        }

        public virtual async Task Add(T Item)
        {
            _context.Add(Item);
            await _context.SaveChangesAsync();
        }

        public virtual async Task AddAll(IEnumerable<T> Items)
        {
            _context.AddRange(Items);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(int Id)
        {
            _context.Remove(await GetByID(Id));
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> Get<T2>(Expression<Func<T, bool>> predicate, Expression<Func<T, T2>> order)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).OrderBy(order).ToListAsync();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByID(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public virtual async Task Save(T Item)
        {
            _context.Update(Item);
            await _context.SaveChangesAsync();
        }

        public virtual async Task SaveAll(IEnumerable<T> Items)
        {
            _context.UpdateRange(Items);
            await _context.SaveChangesAsync();
        }
    }
}