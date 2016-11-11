using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Ado.net
{
    public class AdoNetExample
    {
        
        public AdoNetExample()
        {
            
            //Example with sql connection
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=TransportingCompanyDB; Integrated Security=true");
            SqlCommand cmd = new SqlCommand("Select * from Drivers",con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
           
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}", reader.GetInt32(0),
                        reader.GetString(1),reader.GetString(2));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            con.Close();

            
        }
    }
}
