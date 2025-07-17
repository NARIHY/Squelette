using CefSharp;
using Squelette.Models.Entities.User;
using Squelette.Repositories.Implementations.Users;
using Squelette.Repositories.Interfaces.Users;
using MahApps.Metro.Controls;
using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace Squelette.View
{
    public partial class CustomDesktopWindow : MetroWindow
    {
        private readonly UsersEntity _user;
        private readonly int _logId;

        private readonly IUsersConnexionRepositoryInterface _userRepo = new UsersConnexionRepository();
        private readonly LoginInfoRepository _loginInfo = new LoginInfoRepository();

        public CustomDesktopWindow()
        {
            InitializeComponent();

            Closing += Window_Closing;
            PreviewKeyDown += Window_PreviewKeyDown;
        }

        public CustomDesktopWindow(UsersEntity user, int logId) : this()
        {
            _user = user;
            _logId = logId;
            UserLabel.Text = $"Connecté : {_user.Nom} ({_user.Matricule})";           
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            ArrayLoginInfoView(this, null);
        }


        private void ToggleSidebar_Click(object sender, RoutedEventArgs e)
        {
            Sidebar.Visibility = Sidebar.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            _userRepo.LogUserLogout(_logId);


            var loginWindow = new MainWindow();
            loginWindow.Show();

            Application.Current.MainWindow = loginWindow;
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _userRepo.LogUserLogout(_logId);
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

        

        private void ArrayLoginInfoView(object sender, RoutedEventArgs e)
        {
            var loginC3x = "";
            var passwordC3x = "";
            var loginVoxco = "";
            var passwordVoxco = "";
            if (_user == null)
            {
                MessageBox.Show("Utilisateur non connecté ou non initialisé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var infos = _loginInfo.GetLoginInfoByMatricule(_user.Matricule);
            if (infos != null)
            {
                loginC3x = infos.LoginC3X;
                passwordC3x = infos.PasswordC3X;
                loginVoxco = infos.LoginVoxco;
                passwordVoxco = infos.PasswordVoxco;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Login",typeof(string));
            dt.Columns.Add("Password", typeof(string));


            // Interior
            dt.Rows.Add("C3X", loginC3x, passwordC3x);
            dt.Rows.Add("VOXCO", loginVoxco, passwordVoxco);

            //AFFICHAGE 
            LoginInfoGrid.ItemsSource = dt.DefaultView;
            LoginInfoGrid.Visibility = Visibility.Visible;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
