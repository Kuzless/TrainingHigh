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
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }
        public void AddStudent(StudentDTO student)
        {
            var map = _mapper.Map<Student>(student);
            _studentRepository.AddStudent(map);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        public async Task<StudentDTO> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<IEnumerable<StudentDTO>> GetStudentsByGroupId(int groupid)
        {
            var students = await _studentRepository.GetStudentsByGroupId(groupid);
            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public void UpdateStudent(StudentDTO student)
        {
            var map = _mapper.Map<Student>(student);
            _studentRepository.UpdateStudent(map);
        }
    }
}
