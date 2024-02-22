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
    public class WorkedHoursRepository : GenericRepository<WorkedHours>, IWorkedHoursRepository
    {
        private readonly TrainingContext _context;
        public WorkedHoursRepository(TrainingContext context) : base(context)
        {
            _context = context;
        }
        public void AddWorkedHours(WorkedHours workedHours)
        {
            _context.WorkedHours.Attach(workedHours);
            _context.WorkedHours.Add(workedHours);
            _context.SaveChanges();
        }

        public void DeleteWorkedHours(int id)
        {
            var workedHours = new WorkedHours { Id = id };
            _context.WorkedHours.Attach(workedHours);
            _context.WorkedHours.Remove(workedHours);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<WorkedHours>> GetAllWorkedHours()
        {
            return await _context.Set<WorkedHours>().ToArrayAsync();
        }

        public async Task<WorkedHours> GetWorkedHoursById(int id)
        {
            return await _context.Set<WorkedHours>().FindAsync(id);
        }

        public void UpdateWorkedHours(WorkedHours workedHours)
        {
            _context.WorkedHours.Update(workedHours);
            _context.SaveChanges();
        }
    }
}
