using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeKahoot
{
    internal class manageLeaderboard
    {
        private database db;

        public manageLeaderboard(database databaseInstance)
        {
            db = databaseInstance;
        }

        public List<Leaderboard> getData()
        {

            MySqlConnection conn = db.GetConnection();
            string q = "SELECT * FROM leaderboard";
            MySqlCommand cmd = new MySqlCommand(q, conn);
            List<Leaderboard> result = new List<Leaderboard>();

            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string accountName = reader["accountName"].ToString();
                        string score = reader["score"].ToString();

                        result.Add(new Leaderboard(accountName, score));
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


            return null;
        }

        public bool setData(double score)
        {
            MySqlConnection conn = db.GetConnection();
            string q = "INSERT INTO leaderboard(accountName, score) VALUES(@accountEmail, @score)";
            MySqlCommand cmd = new MySqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@accountEmail", App.UserName);
            cmd.Parameters.AddWithValue("@score", score);
            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Debug.WriteLine("Pushed Score");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            return true;
        }

        public class Leaderboard
        {
            public string accountName { get; set; }
            public string score { get; set; }

            public Leaderboard(string _accountName, string _score)
            {
                accountName = _accountName;
                score = _score;
            }
        }
    }
}
