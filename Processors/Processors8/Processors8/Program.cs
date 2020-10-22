using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors8
{
    class Program
    {
        static List<string> text = new List<string>();
        static StreamReader sr = null;
        static StreamWriter sw = null;
        static List<Task> readline_task;
        static void Main(string[] args)
        {
            readline_task = new List<Task>();
            var read_task = Task.Run(() =>
            {
                using (sr = new StreamReader("file1.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        readline_task.Add(Task.Run(() => { text.Add(sr.ReadLine()); }));
                    }
                    Task.WaitAll(readline_task.ToArray());
                }
            });
            Task.WaitAll(read_task);
            
            var write_task = Task.Run(() =>
            {
                using (sw = new StreamWriter("file2.txt")) {
                    foreach (var item in text.ToArray())
                    {
                        string res;
                        string[] f = item.Split(';');
                        double a, b, c;
                        Double.TryParse(f[0], out a);
                        Double.TryParse(f[1], out b);
                        Double.TryParse(f[2], out c);
                        double d = b * b - 4 * a * c;
                        if (d < 0)
                        {
                            res = "null";
                        }
                        else if (d == 0)
                        {
                            res = "R";
                        }
                        else
                        {
                            res = $"x1 = {(-1 * b + Math.Sqrt(d)) / (2 * a)}, x2 = {(-1 * b - Math.Sqrt(d)) / (2 * a)}";
                        }
                        Console.WriteLine(res);
                        sw.WriteLine(res);
                    }
                }
            });
            Task.WaitAll(write_task);
        }
    }
}
