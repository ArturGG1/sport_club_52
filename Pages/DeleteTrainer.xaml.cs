using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class DeleteTrainer : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private uint trainerId;
    public DeleteTrainer()
    {
        InitializeComponent();
        TrainerID.Text = "";
    }

    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox.Text == "") return;
        try
        {
            trainerId = uint.Parse(textBox.Text);
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
            var trainer = context.Trainers.Find(trainerId);
            if (trainer == null)
            {
                MessageBox.Show($"Тренер с ID {trainerId} не найден!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            context.Trainers.Remove(trainer);
            context.SaveChanges();
        }
        MessageBox.Show("Тренер успешно удалён.","Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
    }
}