using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;
using TrainingApp.DAL.DbConfiguration.DatabaseConfiguration;
using TrainingApp.DAL.Interfaces;

namespace TrainingApp.BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;

        public GroupService(IMapper mapper, IGroupRepository groupRepository) 
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
        }
        public async Task<IEnumerable<GroupDTO>> GetAllGroups()
        {
            var groups = await _groupRepository.GetAllGroups();
            return _mapper.Map<IEnumerable<GroupDTO>>(groups);
        }

        public async Task<GroupDTO> GetGroupById(int groupid)
        {
            var group = await _groupRepository.GetGroupById(groupid);
            return _mapper.Map<GroupDTO>(group);
        }
    }
}
