using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;

namespace TrainingApp.BLL.DTO
{
    public class WorkedHoursDTO
    {
        public int Id { get; set; }
        public int WorkedHoursPlanned { get; set; }
        public int WorkedHoursDone { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public int SubjectTariffId { get; set; }
    }
}
