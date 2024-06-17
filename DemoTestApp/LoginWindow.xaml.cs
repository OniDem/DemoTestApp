using Core.Const;
using Core.Entity;
using DemoTestApp.CookerPage;
using DemoTestApp.AdminPage;
using DemoTestApp.WaiterPage;
using DemoTestApp.Service;
using System.Windows;

namespace DemoTestApp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            UsernameBox.Text = "";
            PasswordBox.Text = "";
        }

        private async void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            UserEntity? user = await UserService.Auth(new() { Username = UsernameBox.Text, Password = PasswordBox.Text });
            if (user != null)
            {
                switch (user.Role)
                {
                    case RoleConst.Admin:
                        AdminMainPage admin = new();
                        admin.Show();
                        Close();
                        break;
                    case RoleConst.Waiter:
                        WaiterMainWindow waiter = new();
                        waiter.Show();
                        Close();
                        break;
                    case RoleConst.Cooker:
                        CookerMainWindow cooker = new();
                        cooker.Show();
                        Close();
                        break;
                }
            }
        }
    }
}
