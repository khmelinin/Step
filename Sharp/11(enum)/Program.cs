using System;

namespace _11_enum_
{
    enum MyStruct:byte
    {
        Zero,
        One,
        Two,
        Three
    }
    enum EnumType : byte
        {
            Zero=0,
            One=1,
            Two=2,
            Three=3
        }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine(EnumType.One);
            Console.WriteLine((byte)EnumType.One);
            EnumType digit = EnumType.Zero;
            Console.WriteLine(digit);
            Console.WriteLine((byte)digit);
        }
    }
}
