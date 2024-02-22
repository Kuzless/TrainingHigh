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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly TrainingContext _context;

        public StudentRepository(TrainingContext context) : base(context)
        {
            _context = context;
        }
        public void AddStudent(Student student)
        {
            _context.Students.Attach(student);
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student student = new Student() { Id = id };
            _context.Students.Attach(student);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Set<Student>().FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetStudentsByGroupId(int groupid)
        {
            return await _context.Set<Student>().Where(x => x.GroupId == groupid).ToArrayAsync();
        }

        public void UpdateStudent(Student student)
        { 
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
