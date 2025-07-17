using Squelette.Commons;
using Squelette.Models.Entities.User;
using Squelette.Repositories.Implementations.Users;
using Squelette.Repositories.Interfaces.Users;
using Squelette.View;
using Squelette.View.Admin;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Squelette
{
    public partial class MainWindow : Window
    {
    private readonly IUsersConnexionRepositoryInterface _userRepo = new UsersConnexionRepository();
    public MainWindow()
        {
            InitializeComponent();
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string matricule = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            try
            {
                UsersEntity? user = _userRepo.GetUser(matricule, password);

                if (user != null)
                {
                    string machineName = MachineHelper.GetMachineName();
                    string machineIp = GetLocalIPAddress();

                    int logId = _userRepo.LogUserLogin(user.Id, machineName, machineIp); 

                    if (user.Role.ToLower() == "admin")
                    {
                        var desktop = new AdministrationDashboard(user, logId);
                        desktop.Show();
                        Close();
                        //Application.Current.Shutdown();
                    }
                    else
                    {
                        var desktop = new CustomDesktopWindow(user, logId); 
                        desktop.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            //MessageBox.Show("La fermeture via Alt+F4 est désactivée. Utilisez le bouton 'Se déconnecter'.");
        }

        
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Alt &&
                (e.SystemKey == Key.F4 || e.SystemKey == Key.Tab))
            {
                e.Handled = true;
            }
        }
    }
}
