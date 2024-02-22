using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface ISubjectNameRepository : IGenericRepository<SubjectName>
    {
        Task<IEnumerable<SubjectName>> GetSubjectNames();
        Task<SubjectName> GetNameById(int id);
    }
}
