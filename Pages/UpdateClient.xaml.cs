using System.Windows;
using System.Windows.Controls;
using sport_club_52.Windows;

namespace sport_club_52.Pages;

public partial class UpdateClient : Page
{
    private UpdateUser updateUser = Application.Current.Windows.OfType<UpdateUser>().FirstOrDefault();
    private uint clientId;
    public UpdateClient()
    {
        InitializeComponent();
    }

    public UpdateClient(Client client, uint clientId)
    {
        InitializeComponent();
        Name.Text = client.Name;
        Password.Password = client.Password;
        Phone.Text = client.Phone;
        Address.Text = client.Address;
        this.clientId = clientId;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if ((sender as Button).Name == "GoBack")
        {
            updateUser.Close();
            return;
        }
        if (Name.Text == "" || Password.Password == "" || Phone.Text == "" || Address.Text == "") return;
        using (var context = new SportClubContext())
        {
            var client = context.Clients.Find(clientId);
            client.Name = Name.Text;
            client.Password = Password.Password;
            client.Phone = Phone.Text;
            client.Address = Address.Text;
            client.Birthday = DateOnly.FromDateTime(Birthday.SelectedDate.Value);
            context.Clients.Update(client);
            context.SaveChanges();
        }
        MessageBox.Show("Данные успешно обновлены.", "ОК", MessageBoxButton.OK, MessageBoxImage.Information);
        updateUser.Close();
    }
}