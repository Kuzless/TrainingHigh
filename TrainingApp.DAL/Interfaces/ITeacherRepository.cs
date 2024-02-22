using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;

namespace TrainingApp.DAL.Interfaces
{
    public interface ITeacherRepository : IGenericRepository<TeacherInfo>
    {
        Task<TeacherInfo> GetTeacherById(int id);
        Task<IEnumerable<TeacherInfo>> GetAllTeachers();
        void AddTeacher (TeacherInfo teacher);
        void UpdateTeacher(TeacherInfo teacher);
        void DeleteTeacher (int id);
    }
}
