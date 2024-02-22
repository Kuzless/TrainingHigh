using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training__DAL_.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Coefficient { get; set; }
        public ICollection<TeacherInfo> TeacherInfos { get; set; }
    }
}
