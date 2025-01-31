using System.Windows;
using System.Windows.Controls;

namespace sport_club_52.Pages;

public partial class Auth : Page
{
    private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    public Auth()
    {
        InitializeComponent();
    }
    public void Button_Click(object sender, RoutedEventArgs e)
    {
        string ButtonName = ((Button)sender).Name;
        string Action = "";
        if (ButtonName.Contains("Create")) Action = "Create";
        else Action = "Login";
        switch (Action)
        {
            case "Create":
            {
                // TODO: добавить странички для создания
                string UserType = ButtonName.Replace("Create", "");
                switch (UserType)
                {
                    case "Trainer":
                        break;
                    case "Cashier":
                        break;
                    case "User":
                        break;
                }
                break;
            }
            case "Login":
            {
                // TODO: добавить странички для входа
                string UserType = ButtonName.Replace("Login", "");
                switch (UserType)
                {
                    case "Trainer":
                        break;
                    case "Cashier":
                        break;
                    case "User":
                        break;
                }
                break;
            }
        }
    }
}