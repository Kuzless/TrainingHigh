using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.BLL.DTO
{
    public class TeacherInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int QualificationId { get; set; }
        public QualificationDTO Qualification { get; set; }
    }
}
