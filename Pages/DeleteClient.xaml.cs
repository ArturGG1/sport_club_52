using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class DeleteClient : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private uint clientId;
    public DeleteClient()
    {
        InitializeComponent();
        clientID.Text = "";
    }

    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox.Text == "") return;
        try
        {
            clientId = uint.Parse(textBox.Text);
        }
        catch (Exception)
        {
            MessageBox.Show("Введите число!","ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if ((sender as Button).Name == "GoBack")
        {
            mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
            return;
        }
        using (var context = new SportClubContext())
        {
            var client = context.Clients.Find(clientId);
            if (client == null)
            {
                MessageBox.Show($"Клиент с ID {clientId} не найден!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            context.Clients.Remove(client);
            context.SaveChanges();
        }
        MessageBox.Show("Клиент успешно удалён.","Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
    }
}