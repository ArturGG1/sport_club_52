using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class CreateClient : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private string clientName = "", clientPassword = "";
    public CreateClient()
    {
        InitializeComponent();
        Name.Text = "";
        Password.Password = "";
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (clientName == "" || clientPassword == "") return;
        using (var context = new SportClubContext())
        {
            var client = new Client() { Name = clientName, Password = clientPassword };
            context.Clients.Add(client);
            context.SaveChanges();
        }
        MessageBox.Show("Клиент успешно создан.", "ОК", MessageBoxButton.OK, MessageBoxImage.Information);
        mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
    }
    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox.Text != "") clientName = textBox.Text;
    }
    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        if (passwordBox.Password != "") clientPassword = passwordBox.Password;
    }
}