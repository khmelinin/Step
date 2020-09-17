using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppADO_l3.Models
{
    class Customer
    {
        DataRow row;

        public Customer(DataRow dataRow)
        {
            row = dataRow;
        }

        public int CustomerId
        {
            get
            {
                return row.Field<int>("customerId");
            }
            set
            {
                row.SetField("customerId", value);
            }
        }

        public string CustomerTitle
        {
            get
            {
                return row.Field<string>("customerTitle");
            }
            set
            {
                row.SetField("customerTitle", value);
            }
        }
    }
}
