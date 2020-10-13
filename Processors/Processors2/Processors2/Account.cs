using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Processors2
{
    public class Account
    {
        decimal balance;
        object sync = new object();
        public Account(decimal d)
        {
            balance = d;
        }

        public decimal Balance
        {
            get
            {
                decimal res;
                Monitor.Enter(sync);
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} entered cs");
                res = balance;
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} leave cs");
                Monitor.Exit(sync);
                return res;
            }
        }

        public void Credit(decimal c)
        {
            if (c < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            lock (sync)
            {
                if (balance > c)
                {
                    balance -= c;
                    Console.WriteLine($"Balance = {balance}");
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            
        }
        public void Debit(decimal d)
        {
            lock (sync)
            {
                if (d < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                balance += d;
                Console.WriteLine($"Balance = {balance}");
            }
        }
    }
}
