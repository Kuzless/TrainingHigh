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
    public class SubjectNameService : ISubjectNameService
    {
        private readonly IMapper _mapper;
        private readonly ISubjectNameRepository _subjectNameRepository;

        public SubjectNameService(IMapper mapper, ISubjectNameRepository subjectNameRepository)
        {
            _mapper = mapper;
            _subjectNameRepository = subjectNameRepository;
        }
        public async Task<IEnumerable<SubjectNameDTO>> GetSubjectNames()
        {
            var subjectNames = await _subjectNameRepository.GetSubjectNames();
            return _mapper.Map<IEnumerable<SubjectNameDTO>>(subjectNames);
        }

        public async Task<SubjectNameDTO> GetNameById(int id)
        {
            var subjectNames = await _subjectNameRepository.GetNameById(id);
            return _mapper.Map<SubjectNameDTO>(subjectNames);
        }
    }
}
