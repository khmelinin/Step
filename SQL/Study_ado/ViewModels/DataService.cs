using Study_ado.Models;
using Study_ado.Models.StudyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Study_ado.Models.StudyDataSet;

namespace Study_ado.ViewModels
{
    internal class DataService
    {
        private StudyDataSet dataset;

        public DataService()
        {
            dataset = new StudyDataSet();
        }

        public void LoadData()
        {
            StudentsTableAdapter adapter = new StudentsTableAdapter();
            adapter.Fill(dataset.Students);
        }

        public void UpdateData()
        {
            StudentsTableAdapter adapter = new StudentsTableAdapter();
            adapter.Update(dataset.Students);
        }

        public IList<StudentViewModel> GetStudents()
        {
            List<StudentViewModel> students = new List<StudentViewModel>();
            foreach (var item in dataset.Students)
            {
                students.Add(new StudentViewModel()
                {
                    StudentID = item.studentId,
                    Name = item.name,
                    Surname = item.surname,
                    Sex = item.IssexNull() ? null : (bool?)item.sex,
                    Birthday = item.IsbirthdayNull() ? null : (DateTime?)item.birthday
                });
            }

            return students;
        }

        public void AddStudent(StudentViewModel student)
        {
            StudentsRow row = dataset.Students.NewStudentsRow();
            row.name = student.Name;
            row.surname = student.Surname;
            if (student.Sex.HasValue)
            {
                row.sex = student.Sex.Value;
            }
            else
            {
                row.SetsexNull();
            }

            if (student.Birthday.HasValue)
            {
                row.birthday = student.Birthday.Value;
            }
            else
            {
                row.SetbirthdayNull();
            }

            dataset.Students.AddStudentsRow(row);
            student.StudentID = row.studentId;
        }

        public void EditStudent(StudentViewModel student)
        {
            var row = dataset.Students.FindBystudentId(student.StudentID);
            if (row == null)
            {
                return;
            }

            row.name = student.Name;
            row.surname = student.Surname;
            if (student.Sex.HasValue)
            {
                row.sex = student.Sex.Value;
            }
            else
            {
                row.SetsexNull();
            }

            if (student.Birthday.HasValue)
            {
                row.birthday = student.Birthday.Value;
            }
            else
            {
                row.SetbirthdayNull();
            }
        }

        public void DeleteStudent(StudentViewModel student)
        {
            var row = dataset.Students.FindBystudentId(student.StudentID);
            if (row == null)
            {
                return;
            }

            row.Delete();
        }
    }
}
