using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Connection.eg1
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            SelectData();
            Console.Read();
        }

        //let us create a common function to get database connection
        private static SqlConnection getConnection()
        {
            con = new SqlConnection(@"data source = ICS-LT-BQ8Q4D3\SQLEXPRESS; initial catalog = infinteDB;" + "user id = Sa; password = Guru6805;");
            con.Open();
            return con;
        }

        //let us create a function to execute sql select statement
        public static void SelectData()
        {
            con = getConnection();
            cmd = new SqlCommand("Select * from tblemployees", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " | " + dr[1] + " | " + dr[2] + " | " + dr[3] + " | " + dr[4] + " | ");
            }
        }
    }
}
