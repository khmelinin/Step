using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_EF_Code_.Models
{
    class SchoolDbContex: DbContext
    {
        public SchoolDbContex():base("FirstEntityProject")
        {
        }

        public DbSet<Student> Students { get; set; }

    }
}
