using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using MySql.Data.MySqlClient;
using static FakeKahoot.database;

namespace FakeKahoot
{
    public class manageQuiz
    {
        private database db;

        public manageQuiz(database databaseInstance)
        {
            db = databaseInstance;
        }

        public List<quiz> getQuiz(string category)
        {
            MySqlConnection mySqlConnection = db.GetConnection(); // Access the MySqlConnection through the database instance

            string q = "SELECT * FROM questions WHERE category = @category";
            List<quiz> questions = new List<quiz>();

            MySqlCommand cmd = new MySqlCommand(q, mySqlConnection);
            cmd.Parameters.AddWithValue("@category", category);

            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string question = reader["question"].ToString();
                        string answer = reader["answer"].ToString();
                        string wrong1 = reader["wrong1"].ToString();
                        string wrong2 = reader["wrong2"].ToString();
                        string wrong3 = reader["wrong3"].ToString();
                        string _category = reader["category"].ToString();

                        questions.Add(new quiz(question, answer, wrong1, wrong2, wrong3, _category));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return questions;
        }

        public class quiz
        {
            public string question { get; set; }
            public string answer { get; set; }
            public string wrong1 { get; set; }
            public string wrong2 { get; set; }
            public string wrong3 { get; set; }
            public string category { get; set; }

            public quiz(string _question, string _answer, string _wrong1, string _wrong2, string _wrong3, string _category)
            {
                question = _question;
                answer = _answer;
                wrong1 = _wrong1;
                wrong2 = _wrong2;
                wrong3 = _wrong3;
                category = _category;
            }
        }
    }
}