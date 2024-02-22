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
    public class SubjectNameRepository : GenericRepository<SubjectName>, ISubjectNameRepository
    {
        private readonly TrainingContext _context;

        public SubjectNameRepository(TrainingContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SubjectName>> GetSubjectNames()
        {
            return await _context.Set<SubjectName>().ToArrayAsync();
        }

        public async Task<SubjectName> GetNameById(int id)
        {
            return await _context.Set<SubjectName>().FindAsync(id);
        }
    }
}
