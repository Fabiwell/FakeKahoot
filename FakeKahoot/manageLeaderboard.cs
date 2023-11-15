using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
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
                        string accountId = reader["account"].ToString();
                        string accountName = reader["accountName"].ToString();
                        string score = reader["score"].ToString();

                        result.Add(new Leaderboard(accountId, accountName, score));
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

        public class Leaderboard
        {
            public string accountId { get; set; }
            public string accountName { get; set; }
            public string score { get; set; }

                public Leaderboard(string _accountId, string _accountName, string _score)
                {
                    accountId = _accountId;
                    accountName = _accountName;
                    score = _score;
                }
            }
        }
    }
}
