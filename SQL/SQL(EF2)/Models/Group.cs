using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_EF2_.Models
{
    public class Group
    {
        public Group()
        {
            Students = new List<Student>();
        }
        public int GroupId { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
