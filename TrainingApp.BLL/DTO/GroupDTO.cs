using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.BLL.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WorkedHoursDTO> WorkedHours { get; set; }
        public ICollection<StudentDTO> Students { get; set; }
    }
}
