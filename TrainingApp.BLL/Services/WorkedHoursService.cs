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
using TrainingApp.DAL.Repositories;

namespace TrainingApp.BLL.Services
{
    public class WorkedHoursService : IWorkedHoursService
    {
        private readonly IMapper _mapper;
        private readonly IWorkedHoursRepository _workedHoursRepository;

        public WorkedHoursService(IMapper mapper, IWorkedHoursRepository workedHoursRepository) 
        {
            _mapper = mapper;
            _workedHoursRepository = workedHoursRepository;
        }
        public void AddWorkedHours(WorkedHoursDTO workedHours)
        {
            var map = _mapper.Map<WorkedHours>(workedHours);
            _workedHoursRepository.AddWorkedHours(map);
        }

        public void DeleteWorkedHours(int id)
        {
            _workedHoursRepository.DeleteWorkedHours(id);
        }

        public async Task<IEnumerable<WorkedHoursDTO>> GetAllWorkedHours()
        {
            var hours = await _workedHoursRepository.GetAllWorkedHours();
            return _mapper.Map<IEnumerable<WorkedHoursDTO>>(hours);
        }

        public async Task<WorkedHoursDTO> GetWorkedHoursById(int id)
        {
            var hour = await _workedHoursRepository.GetWorkedHoursById(id);
            return _mapper.Map<WorkedHoursDTO>(hour);
        }

        public void UpdateWorkedHours(WorkedHoursDTO workedHours)
        {
            var map = _mapper.Map<WorkedHours>(workedHours);
            _workedHoursRepository.UpdateWorkedHours(map);
        }
    }
}
