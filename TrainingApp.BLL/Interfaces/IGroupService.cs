using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;

namespace TrainingApp.BLL.Interfaces
{
    public interface IGroupService
    {
        Task<GroupDTO> GetGroupById(int groupid);
        Task<IEnumerable<GroupDTO>> GetAllGroups();
    }
}
