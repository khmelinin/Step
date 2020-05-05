using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace _22_seriealization_
{[Serializable]
    public class Car : ISerializable
    {
        private string name;
        private int speed;



        public Car(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }
        public void GetData()
        {
            Console.WriteLine("oihih");
            Console.WriteLine("{0}  {1}", name, speed);
        }
        // Специальный вариант конструктора. 
        // SerializationInfo - объект в который помещаем все пары имя-значение представляющие состояние объекта.
        // SerializationInfo - мешок со свойствами (property bag)
        private Car(SerializationInfo propertyBag, StreamingContext context)
        {
            // Значение All перечисления StreamingContextState для свойства context.State, указывает,
            // что данные могут быть переданы в любое место или получены из любого места.
            Console.WriteLine("[ctor] ContextState: {0}", context.State.ToString());



            // Из мешка со свойствами извлекаем значения свойств помещеенных ранее в методе GetObjectData()
            name = propertyBag.GetString("fert");
            speed = propertyBag.GetInt32("speed");
        }




        // Метод ISerializable.GetObjectData() вызывается Formatter-ом
        void ISerializable.GetObjectData(SerializationInfo propertyBag, StreamingContext context)
        {
            // Значение All перечисления StreamingContextState свойства context.State, указывает,
            // что данные могут быть переданы в любое место или получены из любого места.
            Console.WriteLine("[GetObjectData] ContextState: {0}", context.State.ToString());



            // В мешок со свойствами добавляем два свойства и соответственно значения для них.
            propertyBag.AddValue("fert", name);
            propertyBag.AddValue("speed", speed);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Mersedes-Benz-100", 250);
            car.GetData();
            Stream stream = File.Create("car.dat");

            BinaryFormatter formatter = new BinaryFormatter();



            // Сериализация (Вызов метода ISerializable.GetObjectData()).
            formatter.Serialize(stream, car);
            stream.Close();



            stream = File.OpenRead("car.dat");



            // Десериализация (Вызов спецконструктора).
            car = formatter.Deserialize(stream) as Car;
            car.GetData();
            //Console.WriteLine(car.name + "\n" + car.speed);



            // Задержка. 
            Console.ReadKey();
        }
    }
}
