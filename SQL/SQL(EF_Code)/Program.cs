using SQL_EF_Code_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_EF_Code_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (SchoolDbContex school = new SchoolDbContex())
                {
                    var students = school.Students;

                    var s = new Student();
                    s.Name = "Vasya";
                    s.Birthday = new DateTime(1976, 11, 21);
                    students.Add(s);
                    school.SaveChanges();

                    foreach (var st in students)
                    {
                        Console.WriteLine($"{st.StudentId}-{st.Name}");
                    }

                    //var s1 = students.FirstOrDefault();
                    //students.Remove(s1);
                    //school.SaveChanges();
                    //s1 = students.FirstOrDefault();
                    //s1.Sex = true;
                    //var tracker = school.ChangeTracker;
                    school.SaveChanges();

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
