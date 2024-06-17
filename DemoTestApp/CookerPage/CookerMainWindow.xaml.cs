using Core.Const;
using Core.Entity;
using DemoTestApp.Service;
using System.Windows;

namespace DemoTestApp.CookerPage
{
    /// <summary>
    /// Логика взаимодействия для CookerMainWindow.xaml
    /// </summary>
    public partial class CookerMainWindow : Window
    {
        public CookerMainWindow()
        {
            InitializeComponent();
            Dispatcher.Invoke(async () =>
            {
                OrderDG.ItemsSource = await OrderService.ShowAll();
            });
        }

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
            var window = new LoginWindow();
            window.Show();
            Close();
        }

        private async void OrderDG_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var item = OrderDG.SelectedItem as OrderEntity;
            if (item != null)
            {
                if(item.Status == StatusConst.OrderCook)
                    await OrderService.ChangeStatus(new() { OrderId = item.OrderId, Status = StatusConst.OrderCooked });
                else if(item.Status == StatusConst.OrderPaid)
                    await OrderService.ChangeStatus(new() { OrderId = item.OrderId, Status = StatusConst.OrderCook });

                OrderDG.ItemsSource = await OrderService.ShowAll();
            }
        }
    }
}
