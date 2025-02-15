using System.Windows;
using System.Windows.Controls;
using sport_club_52.Windows;

namespace sport_club_52.Pages;

public partial class UpdateTrainer : Page
{
    private UpdateUser updateUser = Application.Current.Windows.OfType<UpdateUser>().FirstOrDefault();
    private uint trainerId = 0;
    public UpdateTrainer()
    {
        InitializeComponent();
    }

    public UpdateTrainer(Trainer trainer, uint trainerId)
    {
        InitializeComponent();
        Name.Text = trainer.Name;
        Password.Password = trainer.Password;
        this.trainerId = trainerId;
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
            var trainer = context.Trainers.Find(trainerId);
            trainer.Name = Name.Text;
            trainer.Password = Password.Password;
            context.Trainers.Update(trainer);
            context.SaveChanges();
        }
        MessageBox.Show("Данные успешно обновлены.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        updateUser.Close();
    }
}