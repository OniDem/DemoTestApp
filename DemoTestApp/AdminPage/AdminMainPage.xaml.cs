using Core.Const;
using System.Windows;

namespace DemoTestApp.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Window
    {
        public AdminMainPage()
        {
            InitializeComponent();
            MessageBox.Show(RoleConst.Admin);
        }
    }
}
