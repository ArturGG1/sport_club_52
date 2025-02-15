using System.Windows;
using System.Windows.Controls;

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
        // TODO: добавить странички для входа
        mainWindow.Frame.Source = new Uri($"Pages/{ButtonName}.xaml", UriKind.Relative);
    }
}