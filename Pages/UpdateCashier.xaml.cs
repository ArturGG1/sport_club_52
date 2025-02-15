using System.Windows;
using System.Windows.Controls;
using sport_club_52.Windows;

namespace sport_club_52.Pages;

public partial class UpdateCashier : Page
{
    private UpdateUser updateUser = Application.Current.Windows.OfType<UpdateUser>().FirstOrDefault();
    private uint cashierId = 0;
    public UpdateCashier()
    {
        InitializeComponent();
    }

    public UpdateCashier(Cashier cashier, uint cashierId)
    {
        InitializeComponent();
        Name.Text = cashier.Name;
        Password.Password = cashier.Password;
        this.cashierId = cashierId;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if ((sender as Button).Name == "GoBack")
        {
            updateUser.Close();
            return;
        }
        if (Name.Text == "" || Password.Password == "") return;
        using (var context = new SportClubContext())
        {
            var cashier = context.Cashiers.Find(cashierId);
            cashier.Name = Name.Text;
            cashier.Password = Password.Password;
            context.Cashiers.Update(cashier);
            context.SaveChanges();
        }
        MessageBox.Show("Данные успешно обновлены.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        updateUser.Close();
    }
}