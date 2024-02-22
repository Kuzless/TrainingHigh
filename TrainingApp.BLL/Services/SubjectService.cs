using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }
        public void AddTariff(string name, string type, float price)
        {
            if (name == null) name = "Error";
            if (type == null) type = "Error";
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            type = char.ToUpper(type[0]) + type.Substring(1).ToLower();
            _subjectRepository.AddTariff(name, type, price);
        }

        public void DeleteTariff(int id)
        {
            _subjectRepository.DeleteTariff(id);
        }

        public async Task<IEnumerable<SubjectTariffDTO>> GetAllTariffs()
        {
            var tariffs = await _subjectRepository.GetAllTariffs();
            return _mapper.Map<IEnumerable<SubjectTariffDTO>>(tariffs);
        }

        public async Task<IEnumerable<SubjectTariffDTO>> GetAllTariffsByName(string name)
        {
            var tariffs = await _subjectRepository.GetAllTariffsByName(name);
            return _mapper.Map<IEnumerable<SubjectTariffDTO>>(tariffs);
        }

        public async Task<SubjectTariffDTO> GetTariffById(int id)
        {
            var tariff = await _subjectRepository.GetTariffById(id);
            return _mapper.Map<SubjectTariffDTO>(tariff);
        }
    }
}
