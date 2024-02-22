using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.DAL.DbConfiguration.DatabaseConfiguration;
using TrainingApp.DAL.Interfaces;

namespace TrainingApp.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TrainingContext _context;

        public GenericRepository(TrainingContext context)
        {
            this._context = context;
        }
        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToArrayAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
