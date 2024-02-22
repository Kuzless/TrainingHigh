using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training__DAL_.Models
{
    public class SubjectType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<SubjectTariff> SubjectTariffs { get; set; }
    }
}
