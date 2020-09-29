using SQL_EF2_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_EF2_
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolDbContext())
            {
                //var g = new Group() { Title = "First" };
                //db.Groups.Add(g);
                //db.SaveChanges();
                //db.Groups.Add(new Group() { Title = "Second" });
                //db.SaveChanges();

                //var groupId = (from g in db.Groups where g.Title == "First" select g.GroupId).FirstOrDefault();
                //foreach (var s in db.Students)
                //{
                //    s.GroupId = groupId;
                //}
                //groupId = (from g in db.Groups where g.Title == "Second" select g.GroupId).FirstOrDefault();
                //db.Students.Add(new Student() { Name = "Vasya", GroupId = groupId });
                //db.Students.Add(new Student() { Name = "Petya", GroupId = groupId });
                //db.SaveChanges();

                //var students = db.Students.Include("Group").ToList();
                //foreach(var s in students)
                //{
                //    Console.WriteLine($"{s.Name} - {s.Group?.Title}");
                //}

                //var groups = db.Groups.Include("Students").ToList();
                //foreach(var g in groups)
                //{
                //    Console.WriteLine(g.Title);
                //    foreach(var s in g.Students)
                //    {
                //        Console.WriteLine($"\t{s.Name}");
                //    }
                //}

                //var students = db.Students.ToList();
                //foreach(var s in students)
                //{
                //    Console.WriteLine($"{s.Name} - {s.Group}");
                //    db.Entry(s).Reference(p => p.Group).Load();
                //    Console.WriteLine();
                //}

                //var group = db.Groups.FirstOrDefault();
                //db.Entry(group).Collection(p => p.Students).Load();
                //Console.WriteLine(group.Title);
                //foreach (var s in group.Students)
                //{
                //    Console.WriteLine($"\t{s.Name}");
                //}


                //var students = db.Students.ToList();
                //foreach (var s in students)
                //{
                //    Console.WriteLine($"{s.Name} - {s.Group?.Title}");

                //}
                //Console.WriteLine();

                var groups = db.Groups.ToList();
                foreach (var group in groups)
                {
                    Console.WriteLine(group.Title);
                    foreach (var s in group.Students)
                    {
                        Console.WriteLine($"\t{s.Name}");
                    }
                }
            }
        }
    }
}
