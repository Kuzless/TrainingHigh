using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface ISalaryRepository : IGenericRepository<Salary>
    {
        Task<Salary> GetSalaryByTeacherId(int id);
        void AddSalary(Salary salary);
        void DeleteSalary(Salary salary);
    }
}
