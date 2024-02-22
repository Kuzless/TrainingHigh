using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;

namespace TrainingApp.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetStudentsByGroupId(int groupid);
        Task<StudentDTO> GetStudentById(int id);
        void AddStudent(StudentDTO student);
        void UpdateStudent(StudentDTO student);
        void DeleteStudent(int id);
    }
}
