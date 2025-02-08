using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class CreateClient : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private string clientName = "", clientPassword = "", clientPhone = "", clientAddress = "";
    private DateOnly clientBirthday = new DateOnly();
    public CreateClient()
    {
        InitializeComponent();
        Name.Text = "";
        Password.Password = "";
        Phone.Text = "";
        Address.Text = "";
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if ((sender as Button).Name == "GoBack") 
            mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
        if (clientName == "" || clientPassword == "" || clientPhone == "" || clientAddress == "") return;
        using (var context = new SportClubContext())
        {
            var client = new Client() { Name = clientName, Password = clientPassword, 
                Birthday = clientBirthday, Phone = clientPhone, Address = clientAddress };
            context.Clients.Add(client);
            context.SaveChanges();
        }
        MessageBox.Show("Клиент успешно создан.", "ОК", MessageBoxButton.OK, MessageBoxImage.Information);
        mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
    }
    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox.Text == "") return;
        switch (textBox.Name)
        {
            case "Name":
            {
                clientName = textBox.Text;
                break;
            }
            case "Phone":
            {
                clientPhone = textBox.Text;
                break;
            }
            case "Address":
            {
                clientAddress = textBox.Text;
                break;
            }
            default:
                break;
        }
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        if (passwordBox.Password != "") clientPassword = passwordBox.Password;
    }

    private void DatePicker_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        var datePicker = sender as DatePicker;
        clientBirthday = DateOnly.FromDateTime(datePicker.SelectedDate.Value);
    }
}