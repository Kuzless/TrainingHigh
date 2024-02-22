using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;

namespace TrainingApp.BLL.Interfaces
{
    public interface ISubjectTypeService
    {
        Task<IEnumerable<SubjectTypeDTO>> GetSubjectTypes();
        Task<SubjectTypeDTO> GetTypeById(int id);
    }
}
