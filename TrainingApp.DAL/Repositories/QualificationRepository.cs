using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;
using TrainingApp.DAL.DbConfiguration.DatabaseConfiguration;
using TrainingApp.DAL.Interfaces;

namespace TrainingApp.DAL.Repositories
{
    public class QualificationRepository : GenericRepository<Qualification>, IQualificationRepository
    {
        private readonly TrainingContext _context;
        public QualificationRepository(TrainingContext context) : base (context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Qualification>> GetAllQualifications()
        {
            return await _context.Set<Qualification>().ToArrayAsync();
        }

        public async Task<Qualification> GetQualifiactionById(int id)
        {
            return await _context.Set<Qualification>().FindAsync(id);
        }
    }
}
