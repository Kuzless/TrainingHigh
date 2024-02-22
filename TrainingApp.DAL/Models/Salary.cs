using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training__DAL_.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public float TeacherSalary { get; set; }
        public int WorkedHoursId { get; set; }
        public WorkedHours WorkedHours { get; set; }
    }
}
