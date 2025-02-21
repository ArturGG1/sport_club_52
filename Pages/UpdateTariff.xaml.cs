using System.Windows;
using System.Windows.Controls;
using sport_club_52.Windows;

namespace sport_club_52.Pages;

public partial class UpdateTariff : Page
{
    private UserPanel userPanel = Application.Current.Windows.OfType<UserPanel>().FirstOrDefault();
    private uint tariffId;
    public UpdateTariff()
    {
        InitializeComponent();
    }

    public UpdateTariff(uint tariffId)
    {
        InitializeComponent();
        Tariff tariff;
        using (var context = new SportClubContext())
        {
            tariff = context.Tariffs.Find(tariffId);
        }
        if (tariff == null)
        {
            userPanel.Frame.GoBack();
            return;
        }
        Title.Text = tariff.Title;
        Description.Text = tariff.Description;
        TrainerId.Text = tariff.TrainerId.ToString();
        Visits.Text = tariff.Visits.ToString();
        Price.Text = tariff.Price.ToString();
        this.tariffId = tariffId;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if ((sender as Button).Name == "GoBack")
        {
            userPanel.Frame.GoBack();
            return;
        }
        if (Title.Text == "" || Description.Text == "" || Visits.Text == "" || Price.Text == "") return;
        using (var context = new SportClubContext())
        {
            var tariff = context.Tariffs.Find(tariffId);
            tariff.Title = Title.Text;
            tariff.Description = Description.Text;
            tariff.TrainerId = uint.Parse(TrainerId.Text);
            tariff.Visits = byte.Parse(Visits.Text);
            tariff.Price = uint.Parse(Price.Text);
            context.Tariffs.Update(tariff);
            context.SaveChanges();
        }
        MessageBox.Show("Данные успешно обновлены.", "ОК", MessageBoxButton.OK, MessageBoxImage.Information);
        userPanel.Frame.GoBack();
    }
}