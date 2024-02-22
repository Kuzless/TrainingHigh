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
    public class TeacherRepository : GenericRepository<TeacherInfo>, ITeacherRepository
    {
        private readonly TrainingContext _context;
        public TeacherRepository(TrainingContext context) : base(context)
        {
            _context = context;
        }
        public void AddTeacher(TeacherInfo teacher)
        {
            _context.Teachers.Attach(teacher);
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void DeleteTeacher(int id)
        {
            TeacherInfo teacherInfo = new TeacherInfo() { Id = id };
            _context.Teachers.Attach(teacherInfo);
            _context.Teachers.Remove(teacherInfo);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TeacherInfo>> GetAllTeachers()
        {
            return await _context.Set<TeacherInfo>().Include(x => x.Qualification).ToArrayAsync();
        }

        public async Task<TeacherInfo> GetTeacherById(int id)
        {
            return await _context.Set<TeacherInfo>().FindAsync(id);
        }

        public void UpdateTeacher(TeacherInfo teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }
    }
}
