using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "GOQ5HV6";//server name
            builder.InitialCatalog = "warehouse";//database name



            //windows auth
            builder.IntegratedSecurity = true;



            //sql server auth
            //builder.UserID = "";
            //builder.Password = "";
            SqlConnection connection = new SqlConnection();
        }
    }
}
