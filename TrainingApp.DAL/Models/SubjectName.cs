using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training__DAL_.Models
{
    public class SubjectName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubjectTariff> SubjectTariffs { get; set; }
    }
}
