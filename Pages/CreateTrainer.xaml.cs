using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class CreateTrainer : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private string trainerName = "", trainerPassword = "";
    public CreateTrainer()
    {
        InitializeComponent();
        Name.Text = "";
        Password.Password = "";
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (trainerName == "" || trainerPassword == "") return;
        using (var context = new SportClubContext())
        {
            var trainer = new Trainer { Name = trainerName, Password = trainerPassword };
            context.Trainers.Add(trainer);
            context.SaveChanges();
        }
        MessageBox.Show("Тренер успешно создан.", "ОК", MessageBoxButton.OK, MessageBoxImage.Information);
        mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
    }
    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox.Text != "") trainerName = textBox.Text;
    }
    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        if (passwordBox.Password != "") trainerPassword = passwordBox.Password;
    }
}