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

namespace FakeKahoot
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        private database db;
        public Leaderboard()
        {
            InitializeComponent();

            db = new database();

            manageLeaderboard leaderboardManager = new manageLeaderboard(db);

            // Call the getData method on the leaderboardManager instance
            List<manageLeaderboard.Leaderboard> leaderboardData = leaderboardManager.getData();
            Trace.WriteLine(leaderboardData);

            foreach (manageLeaderboard.Leaderboard leaderboard in leaderboardData)
            {
                Trace.WriteLine(leaderboard.accountName + " " + leaderboard.score);
                lbLeaderBoard.Items.Add(leaderboard.accountName + " " + leaderboard.score);
            }
        }
    }
}
