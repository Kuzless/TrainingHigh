using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.BLL.DTO;

namespace TrainingApp.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherInfoDTO> GetTeacherById(int id);
        Task<IEnumerable<TeacherInfoDTO>> GetAllTeachers();
        void AddTeacher(TeacherInfoDTO teacher);
        void UpdateTeacher(TeacherInfoDTO teacher);
        void DeleteTeacher(int id);
    }
}
