using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;

namespace TrainingApp.BLL.Interfaces
{
    public interface ISubjectNameService
    {
        Task<IEnumerable<SubjectNameDTO>> GetSubjectNames();
        Task<SubjectNameDTO> GetNameById(int id);
    }
}
