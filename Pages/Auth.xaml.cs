using System.Windows;
using System.Windows.Controls;
using sport_club_52.Windows;

namespace sport_club_52.Pages;

public partial class Auth : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    public Auth()
    {
        InitializeComponent();
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string ButtonName = (sender as Button).Name;
        if (ButtonName.Contains("Update"))
        {
            UpdateUser u = new UpdateUser();
            u.ShowDialog();
            return;
        }
        mainWindow.Frame.Source = new Uri($"Pages/{ButtonName}.xaml", UriKind.Relative);
    }
}