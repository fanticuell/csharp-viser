using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Рыбалка.Classes
{
    public class Connection
    {
        public static MySqlDataReader ConnectionDB(string query)
        {
            string connectString = "server=localhost;port=3306;database=training;user=root;pwd=root";
            MySqlConnection mySqlConnection = new MySqlConnection(connectString);
            mySqlConnection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            return mySqlDataReader;

        }

        public static void LoadUsers(List<Users> users)
        {
            users.Clear();
            string str = "select * from user";
            var connector = ConnectionDB(str);
            while (connector.Read())
            {
                users.Add(new Users(
                        Convert.ToInt32(connector.GetValue(0)),
                         Convert.ToString(connector.GetValue(1)),
                         Convert.ToString(connector.GetValue(2)),
                         Convert.ToString(connector.GetValue(3)),
                         Convert.ToString(connector.GetValue(4)),
                         Convert.ToString(connector.GetValue(5)),
                         Convert.ToString(connector.GetValue(6))));
            }
            connector.Close();
        }

        public static void LoadProducts(List<Products> products)
        {
            products.Clear();
            string str = "select * from product";
            var connector = ConnectionDB(str);
            while (connector.Read())
            {
                products.Add(new Products(
                        Convert.ToString(connector.GetValue(0)),
                         Convert.ToString(connector.GetValue(1)),
                         Convert.ToString(connector.GetValue(2)),
                         Convert.ToString(connector.GetValue(3)),
                         Convert.ToString(connector.GetValue(4)),
                         Convert.ToString(connector.GetValue(5)),
                         Convert.ToString(connector.GetValue(6)),
                         Convert.ToString(connector.GetValue(7)),
                         Convert.ToString(connector.GetValue(8)),
                         Convert.ToString(connector.GetValue(9))));
            }
            connector.Close();
        }
    }
}
