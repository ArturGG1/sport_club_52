using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class CreateCashier : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private string cashierName = "", cashierPassword = "";
    public CreateCashier()
    {
        InitializeComponent();
        Name.Text = "";
        Password.Password = "";
    }

    public void Button_Click(object sender, RoutedEventArgs e)
    {
        if (cashierName == "" || cashierPassword == "") return;
        using (var context = new SportClubContext())
        {
            var cashier = new Cashier { Name = cashierName, Password = cashierPassword };
            context.Cashiers.Add(cashier);
            context.SaveChanges();
        }
        MessageBox.Show("Кассир успешно создан.", "ОК", MessageBoxButton.OK, MessageBoxImage.Information);
        mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
    }
    public void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox.Text != "") cashierName = textBox.Text;
    }
    public void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        if (passwordBox.Password != "") cashierPassword = passwordBox.Password;
    }
}