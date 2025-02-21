using System.Windows;
using System.Windows.Controls;
using sport_club_52.Windows;

namespace sport_club_52.Pages;

public partial class CashierPanel : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private UserPanel userPanel = Application.Current.Windows.OfType<UserPanel>().FirstOrDefault();
    public CashierPanel()
    {
        InitializeComponent();
    }

    public CashierPanel(Cashier cashier)
    {
        InitializeComponent();
        UserName.Text = cashier.Name;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        if (button.Name == "Logout")
        {
            mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
            mainWindow.Show();
            userPanel.Close();
            return;
        }
        userPanel.Frame.Navigate(new Uri($"../Pages/{button.Name}.xaml", UriKind.Relative));
    }
}