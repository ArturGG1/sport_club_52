using System.Windows;
using System.Windows.Controls;
using sport_club_52.Windows;

namespace sport_club_52.Pages;

public partial class CreateTariff : Page
{
    private UserPanel userPanel = Application.Current.Windows.OfType<UserPanel>().FirstOrDefault();
    public CreateTariff()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if ((sender as Button).Name == "GoBack") userPanel.Frame.GoBack();
        if (Title.Text == "" || Description.Text == "" || Visits.Text == "" || Price.Text == "") return;
        using (var context = new SportClubContext())
        {
            try
            {
                var tariff = new Tariff()
                {
                    Title = Title.Text, Description = Description.Text,
                    TrainerId = uint.Parse(TrainerId.Text),
                    Visits = byte.Parse(Visits.Text), Price = uint.Parse(Price.Text)
                };
                context.Tariffs.Add(tariff);
            }
            catch (Exception)
            { }
            context.SaveChanges();
        }
        MessageBox.Show("Тариф успешно создан.", "ОК", MessageBoxButton.OK, MessageBoxImage.Information);
        userPanel.Frame.GoBack();
    }
}