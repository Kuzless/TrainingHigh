using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;
namespace TrainingApp.BLL.Interfaces
{
    public interface ISalaryService
    {
        Task<SalaryDTO> GetSalaryByTeacherId(int id);
        void AddSalary(SalaryDTO salary);
        void DeleteSalary(SalaryDTO salary);
    }
}
