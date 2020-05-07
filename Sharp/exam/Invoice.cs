using System;
using System.Collections.Generic;
using System.Text;

namespace exam
{
    class Invoice
    {
        int account;
        string customer;
        string provider;

        string article;
        int quantity;

        public Invoice(int account, string customer, string provider, string article, int quantity)
        {
            this.account = account;
            this.customer = customer;
            this.provider = provider;
            this.article = article;
            this.quantity = quantity;
            
        }

        public string Article { get => article; set => article = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public int CalcCost(bool NDS)
        {
            try
            {
                switch (article)
                {
                    case "motherboard":
                        if (NDS)
                            return 300 * quantity;
                        else
                            return 300 * quantity - (300 * quantity / 100 * 20);

                    case "cpu":
                        if (NDS)
                            return 600 * quantity;
                        else
                            return 600 * quantity - (600 * quantity / 100 * 20);

                    case "gpu":
                        if (NDS)
                            return 600 * quantity;
                        else
                            return 600 * quantity - (600 * quantity / 100 * 20);
                    case "case":
                        if (NDS)
                            return 100 * quantity;
                        else
                            return 100 * quantity - (100 * quantity / 100 * 20);
                    case "power supply":
                        if (NDS)
                            return 100 * quantity;
                        else
                            return 100 * quantity - (100 * quantity / 100 * 20);
                    default:
                        throw new Exception("!!!nothig found!!!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return -0;
            }
        }
    }
}
