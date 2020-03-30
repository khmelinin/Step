using System;

namespace inheritence
{
    sealed class SealedClass
    {
        int x;
        int y;
    }

    //class Derived2:SealedClass {} 
    class Program
    {
        static void Main(string[] args)
        {
            Derived i = new Derived();
            i.Method();

            //UpCast
            Base iUp = i;
            iUp.Method();

            //DownCast
            Derived iDown = (Derived)iUp;
            iDown.Method();

            
        }
    }
}
