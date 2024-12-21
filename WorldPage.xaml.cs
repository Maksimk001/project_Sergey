using System.Windows;
using System.Windows.Controls;

namespace Play
{
    public partial class WorldPage : Page
    {
        public WorldPage()
        {
            InitializeComponent();
        }

        private void StartQuestions_Click(object sender, RoutedEventArgs e)
        {

            QuestionPage questionPage = new QuestionPage();
            MainFrame.Navigate(questionPage);

        }



        private void VihodStran_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void China_Click(object sender, RoutedEventArgs e)
        {
            ChinaQuest chinaQuest = new ChinaQuest();
            MainFrame.Navigate(chinaQuest);
        }
    }
}
