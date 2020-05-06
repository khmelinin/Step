using System;
using System.Reflection;
using System.IO;

namespace _23_1._1_
{
    class Program
    {
        static void Main(string[] args)
        {
            // При помощи класса Assembly - можно динамически загружать сборки, 
            // обращаться к членам класса в процессе выполнения (ПОЗДНЕЕ СВЯЗЫВАНИЕ),
            // а так же получать информацию о самой сборке.
            Assembly assembly = null;



            try
            {
                // Assembly.Load() - метод для загрузки сборки.
                assembly = Assembly.LoadFrom(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\23(1.1)\bin\Debug\netcoreapp3.1\23(1dll)");
                Console.WriteLine("_23_1dll_ - успешно загружена.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }



            // Выводим информацию о всех типах в сборке.
            ListAllTypes(assembly);
            // Выводим информацию о всех членах в классе.
            ListAllMembers(assembly);
            // Выводим информацию о всех параметрах метода.
            GetParams(assembly);
            /////////////////////////////////////////////////////////////////////////////////
            Type type = assembly.GetType("_23_1dll_.MiniVan");



            object instance = Activator.CreateInstance(type);



            // Получаем экземпляр класса MethodInfo для метода Acceleration(). 
            MethodInfo method = type.GetMethod("Acceleration");



            // Вызов метода Acceleration().
            // Первый параметр - ссылка на экземпляр для которого будет вызван метод Acceleration
            // Второй параметр - массив аргументов метода Acceleration (в данном случае без параметров - null)
            method.Invoke(instance, null);



            // Получаем экземпляр класса MethodInfo для метода Driver(). 
            method = type.GetMethod("Driver");



            // Массив параметров для метода Driver("Shumaher", 36). 
            object[] parameters = { "Shumaher", 36 };



            // Вызов метода Driver().
            // Первый параметр - ссылка на экземпляр для которого будет вызван метод Acceleration
            // Второй параметр - массив аргументов метода Acceleration (в данном случае - name:"Shumaher", age:36 )
            method.Invoke(instance, parameters);


            //Задержка.
            Console.ReadKey();
        }



        // Метод для получения информации о всех типах в сборке.
        private static void ListAllTypes(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));
            Console.WriteLine("\nТипы в: {0} \n", assembly.FullName);



            Type[] types = assembly.GetTypes();



            foreach (Type t in types)
                Console.WriteLine("Тип: {0}", t);
        }



        // Метод для получения информации о членах класса.
        private static void ListAllMembers(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));



            Type type = assembly.GetType("_23_1dll_.MiniVan");



            Console.WriteLine("\nЧлены класса: {0} \n", type);



            MemberInfo[] members = type.GetMembers();



            foreach (MemberInfo element in members)
                Console.WriteLine("{0,-15}:  {1}", element.MemberType, element);
        }



        // Получаем информацию о параметрах для метода TurboBoost() 
        private static void GetParams(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));



            Type type = assembly.GetType("_23_1dll_.MiniVan");
            MethodInfo method = type.GetMethod("Driver"); // Equals , Acceleration, Driver



            // Вывод информации о количестве параметров.
            Console.WriteLine("\nИнформация о параметрах для метода {0}", method.Name);
            ParameterInfo[] parameters = method.GetParameters();
            Console.WriteLine("Метод имеет " + parameters.Length + " параметров");



            // Выводим некоторые характеристики каждого из параметров. 
            foreach (ParameterInfo parameter in parameters)
            {
                Console.WriteLine("Имя параметра: {0}", parameter.Name);
                Console.WriteLine("Позиция в методе: {0}", parameter.Position);
                Console.WriteLine("Тип параметра: {0}", parameter.ParameterType);
            }

        }
    }
}
