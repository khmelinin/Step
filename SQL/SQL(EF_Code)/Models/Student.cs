using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_EF_Code_.Models
{
    class Student
    {
        public int StudentId { get; set; } 
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public bool? Sex { get; set; } 
        public DateTime? Birthday { get; set; }

    }
}
