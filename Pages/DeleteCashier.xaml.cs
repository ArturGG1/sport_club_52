using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class DeleteCashier : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    private uint cashierId;
    public DeleteCashier()
    {
        InitializeComponent();
        cashierID.Text = "";
    }

    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox.Text == "") return;
        try
        {
            cashierId = uint.Parse(textBox.Text);
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
            var cashier = context.Cashiers.Find(cashierId);
            if (cashier == null)
            {
                MessageBox.Show($"Кассир с ID {cashierId} не найден!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            context.Cashiers.Remove(cashier);
            context.SaveChanges();
        }
        MessageBox.Show("Кассир успешно удалён.","Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
    }
}