using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_shop_.Models
{
    public class Product
    {
        double price;

        public string Name { get; set; }
        public string Made_in { get; set; }
        public double Price { get => price;
            set
            {
                if (value < 0)
                    throw new Exception("Price must be >= 0");
                price = value;
            }
        }
        public Product()
        {
            Name = "untiteled";
            Price = 0;
            Made_in = "unknown";
        }
        public override string ToString()
        {
            return $"{Name}, made in {Made_in}, price: {Price}";
        }
    }
}
