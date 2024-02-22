using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface IWorkedHoursRepository : IGenericRepository<WorkedHours>
    {
        Task<WorkedHours> GetWorkedHoursById(int id);
        Task<IEnumerable<WorkedHours>> GetAllWorkedHours();
        void AddWorkedHours (WorkedHours workedHours);
        void UpdateWorkedHours (WorkedHours workedHours);
        void DeleteWorkedHours (int id);
    }
}
