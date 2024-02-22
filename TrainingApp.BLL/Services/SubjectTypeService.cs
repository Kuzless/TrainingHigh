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
    public class SubjectTypeService : ISubjectTypeService
    {
        private readonly IMapper _mapper;
        private readonly ISubjectTypeRepository _subjectTypeRepository;

        public SubjectTypeService(IMapper mapper, ISubjectTypeRepository subjectTypeRepository)
        {
            _mapper = mapper;
            _subjectTypeRepository = subjectTypeRepository;
        }
        public async Task<IEnumerable<SubjectTypeDTO>> GetSubjectTypes()
        {
            var subjectTypes = await _subjectTypeRepository.GetSubjectTypes();
            return _mapper.Map<IEnumerable<SubjectTypeDTO>>(subjectTypes);
        }

        public async Task<SubjectTypeDTO> GetTypeById(int id)
        {
            var subjectTypes = await _subjectTypeRepository.GetTypeById(id);
            return _mapper.Map<SubjectTypeDTO>(subjectTypes);
        }
    }
}
