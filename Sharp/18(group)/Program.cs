using System;
using System.Linq;

// group - является средством для разделения ввода запроса.

namespace _18_group_
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };



            // Построить запрос.
            // Разделение чисел на четные и нечетные.
            var query = from x in numbers
                        group x by x % 2;



            foreach (var gr in query)
            {
                Console.WriteLine("mod{0} == {0}", gr.Key);



                foreach (var number in gr)
                    Console.WriteLine("{0}, ", number);
            }



            // Delay.
            Console.ReadKey();
        }
    }
}