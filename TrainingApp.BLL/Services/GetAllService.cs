using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Repositories;

namespace TrainingApp.BLL.Services
{
    public class GetAllService : IGetAllService
    {
        private readonly IMapper mapper;
        private readonly ITeacherRepository teacherService;
        private readonly IGroupRepository groupService;
        private readonly ISubjectRepository subjectService;
        private readonly IWorkedHoursRepository workedHoursRepository;

        public GetAllService(IMapper mapper, ITeacherRepository teacherService, IGroupRepository groupService, ISubjectRepository subjectService, IWorkedHoursRepository workedHoursRepository) 
        {
            this.groupService = groupService;
            this.subjectService = subjectService;
            this.workedHoursRepository = workedHoursRepository;
            this.mapper = mapper;
            this.teacherService = teacherService;
        }

        public async Task<AllDTO> GetAllByWorkedId(int id)
        {
            var workedrepo = await workedHoursRepository.GetWorkedHoursById(id);
            var worked = mapper.Map<WorkedHoursDTO>(workedrepo);
            var grouprepo = await groupService.GetGroupById(worked.GroupId);
            var group = mapper.Map<GroupDTO>(grouprepo);
            var subjectrepo = await subjectService.GetTariffById(worked.SubjectTariffId);
            var subject = mapper.Map<SubjectTariffDTO>(subjectrepo);
            var teacherrepo = await teacherService.GetTeacherById(worked.TeacherId);
            var teacher = mapper.Map<TeacherInfoDTO>(teacherrepo);
            return new AllDTO()
            {
                TeacherInfoDTO = teacher,
                WorkedHoursDTO = worked,
                GroupDTO = group,
                SubjectTariffDTO = subject,
            };
        }
    }
}
