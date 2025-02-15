using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class LoginClient : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private string clientName = "", clientPassword = "";
    public LoginClient()
    {
        InitializeComponent();
        Name.Text = "";
        Password.Password = "";
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if ((sender as Button).Name == "GoBack")
        {
            mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
            return;
        }
        if (clientName == "" || clientPassword == "") return;
        using (var context = new SportClubContext())
        {
            var client = context.Clients.FirstOrDefault(c => c.Name == clientName && c.Password == clientPassword);
            if (client == null)
            {
                MessageBox.Show("Тренер не найден.\nПроверьте корректность введённых данных.", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        //TODO: сделать страницу для пользователя
    }

    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        clientName = textBox.Text;
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = sender as PasswordBox;
        clientPassword = passwordBox.Password;
    }
}