using System.Windows;
using System.Windows.Controls;

namespace Play
{
    /// <summary>
    /// Логика взаимодействия для Perehod.xaml
    /// </summary>
    public partial class Perehod : Page
    {
        public Perehod()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            WorldPage worldPage = new WorldPage();
            MainPerehodFrame.Navigate(worldPage);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            WorldPage perehodMenu = new WorldPage();
            MainPerehodFrame.Navigate(perehodMenu);
        }

    }
}
