using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class DatabaseOperations
    {
        public static void ReadData()
        {
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=MyTestDb;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Authors";
 
                SqlCommand cmd = new SqlCommand(sql, connection);

                SqlDataReader dreader = cmd.ExecuteReader();

                // for one by one reading row 
                while (dreader.Read())
                {
                    Console.WriteLine(dreader.GetValue(0) + ", " + dreader.GetValue(1));
                }                
            }
        }

        public static void InsertDataAndThenReadData()
        {
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=MyTestDb;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert one more record to the database 
                string sql = "INSERT INTO [dbo].[Authors] VALUES (4, 'Smith')";

                SqlCommand cmd = new SqlCommand(sql, connection);

                SqlDataAdapter adap = new SqlDataAdapter();
                adap.InsertCommand = new SqlCommand(sql, connection);
                adap.InsertCommand.ExecuteNonQuery();

                //Read all records from the database
                sql = "SELECT * FROM Authors";

                cmd = new SqlCommand(sql, connection);

                SqlDataReader dreader = cmd.ExecuteReader();

                // for one by one reading row 
                while (dreader.Read())
                {
                    Console.WriteLine(dreader.GetValue(0) + ", " + dreader.GetValue(1));
                }
            }
        }
    }
}
