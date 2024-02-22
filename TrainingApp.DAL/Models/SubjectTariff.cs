using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training__DAL_.Models
{
    public class SubjectTariff
    {
        public int Id { get; set; }
        public float PricePerHour { get; set; }
        public int subjectNameId { get; set; }
        public int subjectTypeId { get; set; }
        public SubjectName subjectName { get; set; }
        public SubjectType subjectType { get; set; }
        public ICollection<WorkedHours> workedHours { get; set; }
    }
}
