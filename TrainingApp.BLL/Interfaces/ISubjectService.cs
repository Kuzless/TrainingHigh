using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;

namespace TrainingApp.BLL.Interfaces
{
    public interface ISubjectService
    {
        Task<SubjectTariffDTO> GetTariffById(int id);
        Task<IEnumerable<SubjectTariffDTO>> GetAllTariffs();
        Task<IEnumerable<SubjectTariffDTO>> GetAllTariffsByName(string name);
        void AddTariff(string name, string type, float price);
        void DeleteTariff(int id);
    }
}
