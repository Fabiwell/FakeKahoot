using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FakeKahoot
{
    public class manageAccounts
    {
        private MySqlConnection mySqlConnection;

        public manageAccounts() 
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
        public Account CreateAccount(string email, string password, ref bool created)
        {
            string q = "INSERT INTO account(email, password) VALUES (@accountEmail, @accountPassword)";
            MySqlCommand cmd = new MySqlCommand(q, mySqlConnection);
            cmd.Parameters.AddWithValue("@accountEmail", email);
            cmd.Parameters.AddWithValue("@accountPassword", password);

            try
            {
                int affected = cmd.ExecuteNonQuery();

                if(affected > 0)
                {
                    created = true;
                    return new Account(email, password);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                
            }
            return null;
        }

        public Account LoginAccount(string email, string password, ref bool loggedin)
        {
            string q = "SELECT * FROM account WHERE email = @accountEmail AND password = @accountPassword";
            MySqlCommand cmd = new MySqlCommand(q, mySqlConnection);
            cmd.Parameters.AddWithValue("@accountEmail", email);
            cmd.Parameters.AddWithValue("@accountPassword", password);
            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Debug.WriteLine("loggedin");
                        loggedin = true;
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine (ex);
            }
            return null;
        }

        public class Account
        {
            public string email { get; set; } 
            public string password { get; set; }

            public Account(string _email, string _password)
            {
                email = _email;
                password = _password;
            }
        }
    }
}
