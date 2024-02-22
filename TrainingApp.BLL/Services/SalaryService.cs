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
    public class SalaryService : ISalaryService
    {
        private readonly IMapper _mapper;
        private readonly ISalaryRepository _salaryRepository;

        public SalaryService(IMapper mapper, ISalaryRepository salaryRepository) 
        {
            _mapper = mapper;
            _salaryRepository = salaryRepository;
        }

        public void AddSalary(SalaryDTO salary)
        {
            var map = _mapper.Map<Salary>(salary);
            _salaryRepository.AddSalary(map);
        }

        public void DeleteSalary(SalaryDTO salary)
        {
            var map = _mapper.Map<Salary>(salary);
            _salaryRepository.DeleteSalary(map);
        }
        public async Task<SalaryDTO> GetSalaryByTeacherId(int id)
        {
            var salary = await _salaryRepository.GetSalaryByTeacherId(id);
            return _mapper.Map<SalaryDTO>(salary);
        }
    }
}
