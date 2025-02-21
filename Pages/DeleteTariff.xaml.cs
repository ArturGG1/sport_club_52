using System.Windows;
using System.Windows.Controls;
using sport_club_52.Windows;

namespace sport_club_52.Pages;

public partial class DeleteTariff : Page
{
    private UserPanel userPanel = Application.Current.Windows.OfType<UserPanel>().FirstOrDefault();
    private uint tariffId = 0;
    public DeleteTariff()
    {
        InitializeComponent();
        tariffID.Text = "";
    }
    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox.Text == "") return;
        try
        {
            tariffId = uint.Parse(textBox.Text);
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
            userPanel.Frame.GoBack();
            return;
        }
        using (var context = new SportClubContext())
        {
            var tariff = context.Tariffs.Find(tariffId);
            if (tariff == null)
            {
                MessageBox.Show($"Тариф с ID {tariffId} не найден!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            context.Tariffs.Remove(tariff);
            context.SaveChanges();
        }
        MessageBox.Show("Тариф успешно удалён.","Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        userPanel.Frame.GoBack();
    }
}