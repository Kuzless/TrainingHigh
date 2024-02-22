using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Training__DAL_.Models;
using TrainingApp.DAL.DbConfiguration.DatabaseConfiguration;
using TrainingApp.DAL.Interfaces;

namespace TrainingApp.DAL.Repositories
{
    public class SubjectTypeRepository : GenericRepository<SubjectType>, ISubjectTypeRepository
    {
        private readonly TrainingContext _context;

        public SubjectTypeRepository(TrainingContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SubjectType>> GetSubjectTypes()
        {
            return await _context.Set<SubjectType>().ToArrayAsync();
        }

        public async Task<SubjectType> GetTypeById(int id)
        {
            return await _context.Set<SubjectType>().FindAsync(id);
        }
    }
}
