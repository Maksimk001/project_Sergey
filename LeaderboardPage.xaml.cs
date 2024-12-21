using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Play
{
    public partial class LeaderboardPage : Page
    {
        public LeaderboardPage()
        {
            InitializeComponent();
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            var leaderboard = GameManager.Instance.GetLeaderboard();
            LeaderboardItemsControl.ItemsSource = leaderboard;  // Устанавливаем источник данных для ListView
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow(); // Создаем экземпляр нового окна
            newWindow.Show();

            Window.GetWindow(this)?.Close(); // Закрывает текущее окно
        }

    }
}

   

