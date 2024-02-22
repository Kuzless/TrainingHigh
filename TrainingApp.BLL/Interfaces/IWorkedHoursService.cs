using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;

namespace TrainingApp.BLL.Interfaces
{
    public interface IWorkedHoursService
    {
        Task<WorkedHoursDTO> GetWorkedHoursById(int id);
        Task<IEnumerable<WorkedHoursDTO>> GetAllWorkedHours();
        void AddWorkedHours(WorkedHoursDTO workedHours);
        void UpdateWorkedHours(WorkedHoursDTO workedHours);
        void DeleteWorkedHours(int id);
    }
}
