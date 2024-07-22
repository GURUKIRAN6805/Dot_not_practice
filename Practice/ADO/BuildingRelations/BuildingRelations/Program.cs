using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRelations
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Create an in-memory dataset
            DataSet dsEmployment = new DataSet("Employment");

            //2. Create Customers table
            DataTable dtCustomers = new DataTable("Customers");

            //3. Define columns for Customers table
            DataColumn[] dcCustomers = new DataColumn[4];
            dcCustomers[0] = new DataColumn("CustomerID", typeof(int));
            dcCustomers[1] = new DataColumn("CustomerName", typeof(string));
            dcCustomers[2] = new DataColumn("CustomerDept", typeof(string));
            dcCustomers[3] = new DataColumn("CustomerStatusID", typeof(int));

            //4. Add columns to Customers table
            dtCustomers.Columns.AddRange(dcCustomers);

            //5. Add rows to Customers table
            DataRow drCustomerRow = dtCustomers.NewRow();
            drCustomerRow["CustomerID"] = 1;
            drCustomerRow["CustomerName"] = "Aishwarya";
            drCustomerRow["CustomerDept"] = "IT";
            drCustomerRow["CustomerStatusID"] = 1;
            dtCustomers.Rows.Add(drCustomerRow);

            drCustomerRow = dtCustomers.NewRow();
            drCustomerRow["CustomerID"] = 2;
            drCustomerRow["CustomerName"] = "Rajesh";
            drCustomerRow["CustomerDept"] = "Finance";
            drCustomerRow["CustomerStatusID"] = 3;
            dtCustomers.Rows.Add(drCustomerRow);

            drCustomerRow = dtCustomers.NewRow();
            drCustomerRow["CustomerID"] = 3;
            drCustomerRow["CustomerName"] = "Suraj";
            drCustomerRow["CustomerDept"] = "Accounts";
            drCustomerRow["CustomerStatusID"] = 1;
            dtCustomers.Rows.Add(drCustomerRow);

            drCustomerRow = dtCustomers.NewRow();
            drCustomerRow["CustomerID"] = 4;
            drCustomerRow["CustomerName"] = "Swapna";
            drCustomerRow["CustomerDept"] = "Finance";
            drCustomerRow["CustomerStatusID"] = 3;
            dtCustomers.Rows.Add(drCustomerRow);

            drCustomerRow = dtCustomers.NewRow();
            drCustomerRow["CustomerID"] = 5;
            drCustomerRow["CustomerName"] = "Gurukiran";
            drCustomerRow["CustomerDept"] = "Operations";
            drCustomerRow["CustomerStatusID"] = 4;
            dtCustomers.Rows.Add(drCustomerRow);

            drCustomerRow = dtCustomers.NewRow();
            drCustomerRow["CustomerID"] = 6;
            drCustomerRow["CustomerName"] = "Tanmayee";
            drCustomerRow["CustomerDept"] = "Admin";
            drCustomerRow["CustomerStatusID"] = 4;
            dtCustomers.Rows.Add(drCustomerRow);

            //6. Create CustomerStatus table
            DataTable dtCustomerStatus = new DataTable("CustomerStatus");

            //7. Define columns for CustomerStatus table
            DataColumn[] dcStatus = new DataColumn[2];
            dcStatus[0] = new DataColumn("CustomerStatusID", typeof(int));
            dcStatus[1] = new DataColumn("CustomerStatus", typeof(string));

            //8. Add columns to CustomerStatus table
            dtCustomerStatus.Columns.AddRange(dcStatus);

            //9. Add rows to CustomerStatus table
            DataRow drStatus = dtCustomerStatus.NewRow();
            drStatus["CustomerStatusID"] = 1;
            drStatus["CustomerStatus"] = "Full Time";
            dtCustomerStatus.Rows.Add(drStatus);

            drStatus = dtCustomerStatus.NewRow();
            drStatus["CustomerStatusID"] = 2;
            drStatus["CustomerStatus"] = "Part Time";
            dtCustomerStatus.Rows.Add(drStatus);

            drStatus = dtCustomerStatus.NewRow();
            drStatus["CustomerStatusID"] = 3;
            drStatus["CustomerStatus"] = "Contract";
            dtCustomerStatus.Rows.Add(drStatus);

            drStatus = dtCustomerStatus.NewRow();
            drStatus["CustomerStatusID"] = 4;
            drStatus["CustomerStatus"] = "Intern";
            dtCustomerStatus.Rows.Add(drStatus);

            //10. Add both tables to the dataset
            dsEmployment.Tables.Add(dtCustomers);
            dsEmployment.Tables.Add(dtCustomerStatus);

            //11. Set relationship between Customers and CustomerStatus tables
            DataColumn parentColumn = dsEmployment.Tables["CustomerStatus"].Columns["CustomerStatusID"];
            DataColumn childColumn = dsEmployment.Tables["Customers"].Columns["CustomerStatusID"];

            //12. Create data relation
            DataRelation customerRelation = new DataRelation("CustomerStatusRelation", parentColumn, childColumn);

            //13. Add relation to the dataset
            dsEmployment.Relations.Add(customerRelation);

            //14. Display data as per the relationship
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Status ID              |             Customer Status     ");
            Console.WriteLine("--------------------------------------------------------------------------------------");

            foreach (DataRow statusRow in dsEmployment.Tables["CustomerStatus"].Rows)
            {
                Console.WriteLine("{0,-10}             |          {1}", statusRow["CustomerStatusID"], statusRow["CustomerStatus"]);
            }
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("CustomerID \t|    Customer Name\t      |   Department\t       |      Customer Status");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            foreach (DataRow customerRow in dsEmployment.Tables["Customers"].Rows)
            {
                DataRow[] relatedStatusRows = customerRow.GetParentRows(customerRelation);
                if (relatedStatusRows.Length > 0)
                {
                    DataRow statusRow = relatedStatusRows[0];
                    Console.WriteLine("{0,-12}    |      {1,-20}   |     {2,-15}    |       {3}", customerRow["CustomerID"],
                        customerRow["CustomerName"], customerRow["CustomerDept"], statusRow["CustomerStatus"]);
                }
            }

            Console.Read();
        }
    }
}
