using System;

namespace _12_anonimous_methods_
{
    
    class Account
    {
        
        int _sum;
        public delegate void AccountDelegate(string str);
        AccountDelegate account_delegate;
        public void RegisterDeligate(AccountDelegate a)
        {
            this.account_delegate = a;
        }
        public Account(int sum)
        {
            _sum = sum;
        }
        public int CurrentSum
        {
            get => _sum;
            set => _sum = value;
        }
        public void Put(int sum)
        {
            _sum += sum;
        }
        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
                account_delegate("Yes");
            }
            else
            {
                account_delegate("No");
            }
        }
       
    }
    
    public delegate void MyDelegate(ref int a, ref int b, out int c);
    class Program
    {
        
        private static void Show_Message(string m)
        {
            Console.WriteLine(m);
        }
        static void Main(string[] args)
        {
            /*
            Account account = new Account(999);
            Account.AccountDelegate ad=new Account.AccountDelegate(Show_Message);
            account.RegisterDeligate(ad);
            account.Withdraw(3333);
            */

            MyDelegate myDelegate = delegate(ref int x, ref int y, out int z) { x++; y += 5; z = x + y; };
            int s1 = 1, s2 = 6, s3;
            myDelegate(ref s1, ref s2, out s3);
            Console.WriteLine(s1 + " " + s2 + " " + s3);
        }
    }
}
