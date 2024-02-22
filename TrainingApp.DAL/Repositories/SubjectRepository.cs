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
    public class SubjectRepository : GenericRepository<SubjectTariff>, ISubjectRepository
    {
        private readonly TrainingContext _context;

        public SubjectRepository(TrainingContext context) : base(context)
        {
            _context = context;
        }
        public void AddTariff(string name, string type, float price)
        {
            bool nameExists = _context.SubjectNames.Any(x => x.Name == name);
            bool typeExists = _context.SubjectTypes.Any(x => x.Type == type);
            if (!nameExists)
            {
                var subName = new SubjectName() { Name = name };
                _context.SubjectNames.Attach(subName);
                _context.SubjectNames.Add(subName);
            }
            if (!typeExists)
            {
                var subType = new SubjectType() { Type = type };
                _context.SubjectTypes.Attach(subType);
                _context.SubjectTypes.Add(subType);
            }
            _context.SaveChanges();
            var subTariff = new SubjectTariff() { subjectNameId = _context.SubjectNames.Where(x => x.Name == name).FirstOrDefault().Id,
                                                  subjectTypeId = _context.SubjectTypes.Where(x => x.Type == type).FirstOrDefault().Id,
                                                  PricePerHour = price
                                                };
            _context.SubjectTariffes.Attach(subTariff);
            _context.SubjectTariffes.Add(subTariff);
            _context.SaveChanges();
        }

        public void DeleteTariff(int id)
        {
            var subjectTariff = _context.SubjectTariffes.Where(x => x.Id == id).FirstOrDefault();
            if (subjectTariff != null)
            {
                _context.SubjectTariffes.Remove(subjectTariff);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<SubjectTariff>> GetAllTariffs()
        {
            return await _context.Set<SubjectTariff>()
                .Include(x => x.subjectType)
                .Include(x => x.subjectName)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<SubjectTariff>> GetAllTariffsByName(string name)
        {
            return await _context.Set<SubjectTariff>()
                .Include(x => x.subjectType)
                .Include(x => x.subjectName)
                .Where(x => x.subjectName.Name == name)
                .ToArrayAsync();
        }

        public async Task<SubjectTariff> GetTariffById(int id)
        {
            return await _context.Set<SubjectTariff>().Include(x => x.subjectType)
                .Include(x => x.subjectName)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
