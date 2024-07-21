using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disconnected
{
    class Program
    {
        public static SqlConnection con = null;
        public static SqlDataAdapter da;
        static void Main(string[] args)
        {
            Disconnected_approach();
            Console.Read();
        }

        public static void Disconnected_approach()
        {
            con = new SqlConnection("data source = ICS-LT-BQ8Q4D3\\SQLEXPRESS; initial catalog = NorthwindDB;" +
                 "user id = sa; password = Guru6805;");
            con.Open();
            da = new SqlDataAdapter("select * from Region", con);
            DataSet ds = new DataSet();

            da.Fill(ds, "NorthwindRegion");
            DataTable dt = ds.Tables["NorthwindRegion"];

            //to access the rows and columns from the datatable
            foreach (DataRow drow in dt.Rows)
            {
                foreach (DataColumn dcol in dt.Columns)
                {
                    Console.Write(drow[dcol]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

        }
    }
}

