using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_EF2_.Models
{
    class SchoolDbContext:DbContext
    {
        public SchoolDbContext():base()
        {

        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
