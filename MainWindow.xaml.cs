using System.Windows;

namespace Play
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PlayerNameTextBox.Text))
            {
                GameManager.Instance.PlayerName = PlayerNameTextBox.Text;

                WorldPage worldPage = new WorldPage();
                this.Content = worldPage; // Переход на WorldPage
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите имя игрока.");
            }
        }

        private void ShowLeaderBoard_Click(object sender, RoutedEventArgs e)
        {
            LeaderboardPage leaderboardPage = new LeaderboardPage();
            this.Content = leaderboardPage; // Переход на LeaderboardPage
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Пример метода для добавления очков (вызывайте его по событию игры)
        private void AddPoints(int points)
        {
            GameManager.Instance.AddScore(points);
        }

    }
}
