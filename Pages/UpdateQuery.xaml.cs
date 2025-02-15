using System.Windows;
using System.Windows.Controls;
using sport_club_52.Windows;

namespace sport_club_52.Pages;

public partial class UpdateQuery : Page
{
    private UpdateUser updateUser = Application.Current.Windows.OfType<UpdateUser>().FirstOrDefault();
    private uint userId = 0;
    private string userType = "Trainer";
    public UpdateQuery()
    {
        InitializeComponent();
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
        RadioButton radioButton = sender as RadioButton;
        userType = radioButton.Name;
    }

    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        try
        {
            userId = Convert.ToUInt32(textBox.Text);
        }
        catch (Exception)
        {
            MessageBox.Show("Некорректный ID!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (userId == 0 || userType == "") return;
        using (var context = new SportClubContext())
        {
            switch (userType)
            {
                case "Trainer":
                {
                    var trainer = context.Trainers.Find(userId);
                    if (trainer == null)
                    {
                        MessageBox.Show($"Тренер с ID {userId} не найден!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    UpdateTrainer ut = new UpdateTrainer(trainer, userId);
                    updateUser.Frame.Navigate(ut);
                    break;
                }
                case "Cashier":
                {
                    var cashier = context.Cashiers.Find(userId);
                    if (cashier == null)
                    {
                        MessageBox.Show($"Кассир с ID {userId} не найден!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    UpdateCashier uc = new UpdateCashier(cashier, userId);
                    updateUser.Frame.Navigate(uc);
                    break;
                }
                case "Client":
                {
                    var client = context.Clients.Find(userId);
                    if (client == null)
                    {
                        MessageBox.Show($"Клиент с ID {userId} не найден!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    UpdateClient uc = new UpdateClient(client, userId);
                    updateUser.Frame.Navigate(uc);
                    break;
                }
                default:
                    break;
            }
        }
    }
}