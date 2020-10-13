using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Processors2
{
    class Program
    {
        static Account account;
        static void Main(string[] args)
        {
            account = new Account(1000);
            Thread[] threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    threads[i] = new Thread(DebitAccount);
                }
                else
                {
                    threads[i] = new Thread(CreditAccount);
                }
            }
            foreach (var item in threads)
            {
                item.Start();
            }
            foreach (var item in threads)
            {
                item.Join();
            }
            Console.ReadLine();
        }

        private static void CreditAccount()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    //Console.WriteLine(account.Balance);
                    account.Credit(rnd.Next(100, 1000));
                    //Console.WriteLine(account.Balance);
                }
                catch
                {
                    Console.WriteLine("Credit catch");
                }
            }
        }

        private static void DebitAccount()
        {
            Random rnd = new Random();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    //Console.WriteLine(account.Balance);
                    account.Debit(rnd.Next(100, 1000));
                    //Console.WriteLine(account.Balance);
                }
            }
            catch
            {
                Console.WriteLine("Debit catch");
            }
        }
    }
}
