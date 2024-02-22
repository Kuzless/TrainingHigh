using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training__DAL_.Models
{
    public class WorkedHours
    {
        public int Id { get; set; }
        public int WorkedHoursPlanned { get; set; }
        public int WorkedHoursDone { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public int SubjectTariffId {  get; set; }
        public ICollection<Salary> Salarys { get; set; }
        public TeacherInfo Teacher { get; set; }
        public Group Group { get; set; }
        public SubjectTariff SubjectTariff { get; set; }
    }
}
