using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static FakeKahoot.database;

namespace FakeKahoot
{
    /// <summary>
    /// Interaction logic for indvQuiz.xaml
    /// </summary>
    
    public partial class indvQuiz : Window
    {
        private database db;
        Random rand = new Random();
        private List<manageQuiz.quiz> quizList;
        private List<string> answerList = new List<string>();
        int toRemove;
        int index;
        public indvQuiz(string category)
        {
            db = new database();
            manageQuiz manageQuiz = new manageQuiz(db);
            InitializeComponent();
            quizList = manageQuiz.getQuiz(category).ToList();
            index = quizList.Count;
            quizList.Shuffle();
            


            index--;
            fillContent(index, quizList);
            index--;
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string answer = button.Content.ToString();

            if (index > 0)
            {
                answerList.Add(answer);

                fillContent(index, quizList);
                index--;
            }
            else
            {
                fillContent(index, quizList);

                int correctAnswers = 0;

                foreach (string answeredQuestion in answerList)
                {
                    // Find the corresponding question in the list
                    manageQuiz.quiz question = quizList.Find(q => q.answer == answeredQuestion);

                    if (question != null)
                    {
                        Trace.WriteLine(answeredQuestion + " | " + question.answer);
                        // Compare the user's answer to the correct answer
                        if (answeredQuestion == question.answer) ;
                        {
                            correctAnswers++;
                        }
                    }
                }
                // Calculate the user's score
                double userScore = ((double)correctAnswers / answer.Length) * 100;

                Trace.WriteLine("User's Score: " + userScore + "%");

                Window.GetWindow(this).Close();
                manageLeaderboard leaderboardManager = new manageLeaderboard(db);
                bool result = leaderboardManager.setData(userScore);
                Leaderboard leaderboard = new Leaderboard();

                leaderboard.Show();

            }
        }

        private void fillContent(int index, List<manageQuiz.quiz> quizList)
        {
            string[] answers = { quizList[index].answer, quizList[index].wrong1, quizList[index].wrong2, quizList[index].wrong3 };
            int amount;

            if (index < 0 || index >= quizList.Count)
            {
                Trace.WriteLine("Index out of range");
                return;
            }

            lblTitle.Text = quizList[index].question;


            toRemove = rand.Next(0, 3);
            btnQuestion1.Content = answers[toRemove];
            answers = removeRandom(answers, toRemove);

            toRemove = rand.Next(0, 2);
            btnQuestion2.Content = answers[toRemove];
            answers = removeRandom(answers, toRemove);

            toRemove = rand.Next(0, 1);
            btnQuestion3.Content = answers[toRemove];
            answers = removeRandom(answers, toRemove);

            btnQuestion4.Content = answers[0];
            
            lblAmountNumber.Text = index.ToString();

            index--;
        }

        private string[] removeRandom(string[] answers, int indexToRemove)
        {
            string[] newAnswers = new string[answers.Length - 1];


            for (int i = 0, j = 0; i < answers.Length; i++)
            {
                if (i != indexToRemove)
                {
                    newAnswers[j] = answers[i];
                    j++;
                }
            }

            return newAnswers;
        }
    }
}
