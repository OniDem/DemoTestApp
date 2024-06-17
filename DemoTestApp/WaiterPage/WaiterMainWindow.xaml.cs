using Core.Const;
using Core.Entity;
using DemoTestApp.Service;
using System.Windows;
using System.Windows.Controls;

namespace DemoTestApp.WaiterPage
{
    /// <summary>
    /// Логика взаимодействия для WaiterMainWindow.xaml
    /// </summary>
    public partial class WaiterMainWindow : Window
    {
        public WaiterMainWindow()
        {
            InitializeComponent();
            Dispatcher.Invoke(async () =>
            {
                OrderDG.ItemsSource = await OrderService.ShowAll();
            });
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new LoginWindow();
            window.Show();
            Close();
        }

        private async void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var order = await OrderService.Add(new() {  Table = Convert.ToInt32(TableBox.Text), ClientCount = Convert.ToInt32(ClientCountBox.Text), OrderText = OrderTextBox.Text });
            if(order != null)
            {
                OrderDG.ItemsSource = await OrderService.ShowAll();
                TableBox.Text = "";
                ClientCountBox.Text = "";
                OrderTextBox.Text = "";
            }
        }

        private async void OrderDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = OrderDG.SelectedItem as OrderEntity;
            if (item != null)
            {
                if (item.Status == StatusConst.OrderOpened)
                    await OrderService.ChangeStatus(new() { OrderId = item.OrderId, Status = StatusConst.OrderPaid });

                OrderDG.ItemsSource = await OrderService.ShowAll();
            }
        }
    }
}
