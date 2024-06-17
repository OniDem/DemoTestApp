using Core.Entity;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net;
using Core.DTO.Order;

namespace DemoTestApp.Service
{
    public class OrderService
    {
        public static async Task<OrderEntity?> Add(AddOrderRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("http://localhost:5250/Order/Add", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var order = await response.Content.ReadFromJsonAsync<OrderEntity>();
                    return order;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static async Task<IEnumerable<OrderEntity>?> ShowAll()
        {
            try
            {
                JsonContent content = JsonContent.Create("");
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("" +
                    "http://localhost:5250/Order/ShowAll", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var orders = await response.Content.ReadFromJsonAsync<IEnumerable<OrderEntity>>();
                    return orders;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static async Task<OrderEntity?> ChangeStatus(ChangeOrderStatusRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PutAsync("http://localhost:5250/Order/ChangeStatus", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var order = await response.Content.ReadFromJsonAsync<OrderEntity>();
                    return order;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
