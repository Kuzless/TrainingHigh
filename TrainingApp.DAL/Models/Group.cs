using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training__DAL_.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WorkedHours> WorkedHours { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
