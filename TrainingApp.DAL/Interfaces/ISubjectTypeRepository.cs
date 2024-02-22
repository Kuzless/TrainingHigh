using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface ISubjectTypeRepository : IGenericRepository<SubjectType>
    {
        Task<IEnumerable<SubjectType>> GetSubjectTypes();
        Task<SubjectType> GetTypeById(int id);
    }
}
