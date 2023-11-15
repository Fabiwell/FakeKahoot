using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeKahoot
{
    public class database
    {
        private MySqlConnection mySqlConnection;
        public database()
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=fake-kahoot; password=";
            mySqlConnection = new MySqlConnection(mysqlCon);

            try
            {
                mySqlConnection.Open();
                Debug.WriteLine("Connection Succesful");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public MySqlConnection GetConnection()
        {
            return mySqlConnection;
        }

    }
}
