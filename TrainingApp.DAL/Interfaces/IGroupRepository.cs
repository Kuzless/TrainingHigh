using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        Task<Group> GetGroupById(int groupid);
        Task<IEnumerable<Group>> GetAllGroups();
    }
}
