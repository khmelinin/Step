using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_EF2_.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool? Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
