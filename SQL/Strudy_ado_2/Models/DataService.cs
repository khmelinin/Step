using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strudy_ado_2.Models
{
    class DataService
    {
        StudyDataClassesDataContext dataContext = new StudyDataClassesDataContext();

        public IEnumerable<Student> GetStudents()
        {
            return dataContext.Students;
        }

        public void AddStudent(Student student)
        {
            dataContext.Students.InsertOnSubmit(student);
        }

        public void DeleteStudent(Student student)
        {
            dataContext.Students.DeleteOnSubmit(student);
        }

        public void SaveChanges()
        {
            dataContext.SubmitChanges();
        }
    }
}
