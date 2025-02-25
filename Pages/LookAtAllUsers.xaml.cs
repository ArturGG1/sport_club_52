﻿using System.Windows;
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
                        tb.Text = $"ID {client.Id}:\t\"{client.Name}\"\n" +
                                  $"Пароль: \"{client.Password}\"\n" +
                                  $"День рождения: {client.Birthday}\n" +
                                  $"Номер телефона: {client.Phone}\n" +
                                  $"Адрес: {client.Address}\n" +
                                  $"ID абонемента: {client.MembershipId}\n" +
                                  $"Номер шкафа:{client.BoxId}\n\n";
                        Panel.Children.Add(tb);
                    }
                    break;
                }
                case "Tariffs":
                {
                    var tariffs = context.Tariffs.ToList();
                    if (tariffs.Count == 0)
                    {
                        TextBlock tb = new TextBlock();
                        tb.FontSize = 18;
                        tb.Text = "(тарифов нет)";
                        Panel.Children.Add(tb);
                        break;
                    }
                    foreach (var tariff in tariffs)
                    {
                        TextBlock tb = new TextBlock();
                        tb.FontSize = 18;
                        tb.Text = $"ID {tariff.Id}:\tТариф \"{tariff.Title}\"\n" +
                                  $"{tariff.Description}\n" +
                                  $"ID тренера: {tariff.TrainerId}\n" +
                                  $"Кол-во посещений: {tariff.Visits}\n" +
                                  $"Стоимость: {tariff.Price} руб.\n\n";
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