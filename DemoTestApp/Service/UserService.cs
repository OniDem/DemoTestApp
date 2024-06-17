using Core.DTO.User;
using Core.Entity;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net;

namespace DemoTestApp.Service
{
    public static class UserService
    {

        public static async Task<UserEntity?> Auth(AuthUserRequest request)
        {
            try
            {
                JsonContent content = JsonContent.Create(request);
                HttpClient httpClient = new();
                var response = await httpClient.PostAsync("http://localhost:5250/User/Auth", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var user = await response.Content.ReadFromJsonAsync<UserEntity>();
                    if (user!.UserId > 0)
                    {
                        return user;

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
