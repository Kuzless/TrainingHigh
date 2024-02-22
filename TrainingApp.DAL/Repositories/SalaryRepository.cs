using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;
using TrainingApp.DAL.DbConfiguration.DatabaseConfiguration;
using TrainingApp.DAL.Interfaces;

namespace TrainingApp.DAL.Repositories
{
    public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
    {
        private readonly TrainingContext _context;
        public SalaryRepository(TrainingContext context) : base(context)
        {
            _context = context;
        }

        public void AddSalary(Salary salary)
        {
            _context.Salarys.Attach(salary);
            _context.Salarys.Add(salary);
            _context.SaveChanges();
        }

        public void DeleteSalary(Salary salary)
        {
            _context.Salarys.Attach(salary);
            _context.Salarys.Remove(salary);
            _context.SaveChanges();
        }

        public async Task<Salary> GetSalaryByTeacherId(int id)
        {
            return await _context.Set<Salary>().Include(x => x.WorkedHours).Where(x => x.WorkedHours.TeacherId == id).FirstOrDefaultAsync();
        }
    }
}
