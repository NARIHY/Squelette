using Squelette.Models.Entities.User;
using Squelette.Repositories.Implementations.Users;
using Squelette.Repositories.Interfaces.Users;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Squelette.View.Admin
{
    /// <summary>
    /// Logique d'interaction pour AdministrationTableauDeBord.xaml
    /// </summary>
    public partial class AdministrationDashboard : MetroWindow
    {
        private readonly int _logId;
        private readonly UsersEntity _user;

        private readonly IUsersConnexionRepositoryInterface _userRepo = new UsersConnexionRepository();


        public AdministrationDashboard()
        {
            InitializeComponent();
            Closing += Window_Closing;
            PreviewKeyDown += Window_PreviewKeyDown;
        }

        public AdministrationDashboard(UsersEntity user, int logId): this()
        {
            this._user = user;
            this._logId = logId;

            //Closing

            Closing += Window_Closing;
            PreviewKeyDown += Window_PreviewKeyDown;
        }


        private void HamburgerMenuControl_OnItemInvoked(object sender, MahApps.Metro.Controls.HamburgerMenuItemInvokedEventArgs e)
        {
            if (e.InvokedItem is HamburgerMenuIconItem item)
            {
                switch (item.Tag?.ToString())
                {
                    case "Dashboard":
                        // Naviguer vers le dashboard
                        break;
                    case "Users":
                        // Naviguer vers utilisateurs
                        break;
                    case "Stats":
                        // Naviguer vers stats
                        break;
                    case "Settings":
                        // Naviguer vers settings
                        break;
                    case "Logout":
                        Logout_Click();
                        break;
                }
            }
        }
        private void Logout_Click()
        {
            _userRepo.LogUserLogout(_logId);
            this.Close();

            //CLose app
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Alt) &&
                (e.SystemKey == Key.F4 || e.SystemKey == Key.Tab))
            {
                e.Handled = true;
            }
        }
    }
}
