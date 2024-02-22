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
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        private readonly TrainingContext _context;

        public GroupRepository(TrainingContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await _context.Set<Group>().ToArrayAsync();
        }

        public async Task<Group> GetGroupById(int groupid)
        {
            return await _context.Set<Group>().Include(x => x.Students).Where(x => x.Id == groupid).FirstOrDefaultAsync();
        }
    }
}
