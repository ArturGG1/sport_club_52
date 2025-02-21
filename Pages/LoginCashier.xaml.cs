using System.Windows;
using System.Windows.Controls;
using sport_club_52.Windows;

namespace sport_club_52.Pages;

public partial class LoginCashier : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private string cashierName = "", cashierPassword = "";
    public LoginCashier()
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
        if (cashierName == "" || cashierPassword == "") return;
        using (var context = new SportClubContext())
        {
            var cashier = context.Cashiers.FirstOrDefault(c => c.Name == cashierName && c.Password == cashierPassword);
            if (cashier == null)
            {
                MessageBox.Show("Кассир не найден.\nПроверьте корректность введённых данных.", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UserPanel userPanel = new UserPanel();
            CashierPanel cashierPanel = new CashierPanel(cashier);
            userPanel.Frame.Navigate(cashierPanel);
            userPanel.Show();
            mainWindow.Hide();
        }
    }

    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        cashierName = textBox.Text;
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = sender as PasswordBox;
        cashierPassword = passwordBox.Password;
    }
}