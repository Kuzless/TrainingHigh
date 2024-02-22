using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface IQualificationRepository : IGenericRepository<Qualification>
    {
        Task<Qualification> GetQualifiactionById(int id);
        Task<IEnumerable<Qualification>> GetAllQualifications();
    }
}
