using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;
using TrainingApp.DAL.Interfaces;

namespace TrainingApp.BLL.Services
{
    public class QualificationService : IQualificationService
    {
        private readonly IMapper _mapper;
        private readonly IQualificationRepository _qualificationRepository;

        public QualificationService(IMapper mapper, IQualificationRepository qualificationRepository)
        {
            _mapper = mapper;
            _qualificationRepository = qualificationRepository;
        }
        public async Task<IEnumerable<QualificationDTO>> GetAllQualifications()
        {
            var qualifications = await _qualificationRepository.GetAllQualifications();
            return _mapper.Map<IEnumerable<QualificationDTO>>(qualifications);
        }

        public async Task<QualificationDTO> GetQualifiactionById(int id)
        {
            var qualifications = await _qualificationRepository.GetQualifiactionById(id);
            return _mapper.Map<QualificationDTO>(qualifications);
        }
    }
}
