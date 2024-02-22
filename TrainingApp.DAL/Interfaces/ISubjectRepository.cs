using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface ISubjectRepository : IGenericRepository<SubjectTariff>
    {
        Task<SubjectTariff> GetTariffById(int id);
        Task<IEnumerable<SubjectTariff>> GetAllTariffs();
        Task<IEnumerable<SubjectTariff>> GetAllTariffsByName(string name);
        void AddTariff(string name, string type, float price);
        void DeleteTariff(int id);
    }
}
