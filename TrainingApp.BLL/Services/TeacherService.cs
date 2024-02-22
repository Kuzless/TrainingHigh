using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;
using TrainingApp.DAL.Interfaces;

namespace TrainingApp.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(IMapper mapper, ITeacherRepository teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public void AddTeacher(TeacherInfoDTO teacher)
        {
            var map = _mapper.Map<TeacherInfo>(teacher);
            _teacherRepository.AddTeacher(map);
        }

        public void DeleteTeacher(int id)
        {
            _teacherRepository.DeleteTeacher(id);
        }

        public async Task<IEnumerable<TeacherInfoDTO>> GetAllTeachers()
        {
            var teachers = await _teacherRepository.GetAllTeachers();
            return _mapper.Map<IEnumerable<TeacherInfoDTO>>(teachers);
        }

        public async Task<TeacherInfoDTO> GetTeacherById(int id)
        {
            var teacher = await _teacherRepository.GetTeacherById(id);
            return _mapper.Map<TeacherInfoDTO>(teacher);
        }

        public void UpdateTeacher(TeacherInfoDTO teacher)
        {
            var map = _mapper.Map<TeacherInfo>(teacher);
            _teacherRepository.UpdateTeacher(map);
        }
    }
}
