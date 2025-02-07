using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class LookAtAllUsers : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    public LookAtAllUsers()
    {
        InitializeComponent();
        Panel.Children.Clear();
    }

    private void UpdatePanel(string Type)
    {
        //TODO: передалать эти костыли
        Panel.Children.Clear();
        using (var context = new SportClubContext())
        {
            switch (Type)
            {
                case "Trainers":
                {
                    var trainers = context.Trainers.ToList();
                    if (trainers.Count == 0)
                    {
                        TextBlock tb = new TextBlock();
                        tb.FontSize = 18;
                        tb.Text = "(тренеров нет)";
                        Panel.Children.Add(tb);
                        break;
                    }
                    foreach (var trainer in trainers)
                    {
                        TextBlock tb = new TextBlock();
                        tb.FontSize = 18;
                        tb.Text = $"ID {trainer.Id}:\t\"{trainer.Name}\" с паролем \"{trainer.Password}\"";
                        Panel.Children.Add(tb);
                    }
                    break;
                }
                case "Cashiers":
                {
                    var cashiers = context.Cashiers.ToList();
                    if (cashiers.Count == 0)
                    {
                        TextBlock tb = new TextBlock();
                        tb.FontSize = 18;
                        tb.Text = "(кассиров нет)";
                        Panel.Children.Add(tb);
                        break;
                    }
                    foreach (var cashier in cashiers)
                    {
                        TextBlock tb = new TextBlock();
                        tb.FontSize = 18;
                        tb.Text = $"ID {cashier.Id}:\t\"{cashier.Name}\" с паролем \"{cashier.Password}\"";
                        Panel.Children.Add(tb);
                    }
                    break;
                }
                case "Clients":
                {
                    var clients = context.Clients.ToList();
                    if (clients.Count == 0)
                    {
                        TextBlock tb = new TextBlock();
                        tb.FontSize = 18;
                        tb.Text = "(клиентов нет)";
                        Panel.Children.Add(tb);
                        break;
                    }
                    foreach (var client in clients)
                    {
                        TextBlock tb = new TextBlock();
                        tb.FontSize = 18;
                        tb.Text = $"ID {client.Id}:\t\"{client.Name}\" с паролем \"{client.Password}\"";
                        Panel.Children.Add(tb);
                    }
                    break;
                }
                default:
                    break;
            }
        }
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string Type = (sender as Button).Name;
        UpdatePanel(Type);
    }
    private void GoBack(object sender, RoutedEventArgs e)
    {
        mainWindow.Frame.Source = new Uri("Pages/Auth.xaml", UriKind.Relative);
    }
}