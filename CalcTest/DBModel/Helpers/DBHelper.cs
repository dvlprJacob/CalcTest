using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCalc.Managers; 
using System.Collections;

namespace WebCalc.Helpers
{
    public class DBHelper
    {
        public const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jacob\Desktop\Elma\Tasks\CalcTest\DBModel\App_Data\CalcStorage.mdf;Integrated Security=True";
        public static IEnumerable<object> GetAllFromTable(string table)
        {
            var result = new List<object>();

            var sqlquery = $"SELECT * FROM {table}";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sqlquery, conn);

                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var itemCount = reader.FieldCount;
                    while (reader != null && reader.Read())
                    {
                        var item = new Dictionary<int, object>();

                        for(int i=0;i<itemCount;i++)
                        {
                            item.Add(i, reader[i]);
                        }

                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public static void InsertTable(string table,IEnumerable<object> item)
        {
            var result = new List<object>();

            var values = item.Select(i => i is string || i is DateTime
            ? $"'{i}'"
            : $"{i}");

            var sqlquery = $"INSERT INTO {table} VALUES({string.Join(", ", values)})";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sqlquery, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}