using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class LoginTrainer : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private string trainerName = "", trainerPassword = "";
    public LoginTrainer()
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
        if (trainerName == "" || trainerPassword == "") return;
        using (var context = new SportClubContext())
        {
            var trainer = context.Trainers.FirstOrDefault(t => t.Name == trainerName && t.Password == trainerPassword);
            if (trainer == null)
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
        trainerName = textBox.Text;
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = sender as PasswordBox;
        trainerPassword = passwordBox.Password;
    }
}