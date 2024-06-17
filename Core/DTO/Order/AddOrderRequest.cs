namespace Core.DTO.Order
{
    public class AddOrderRequest
    {
        public int Table {  get; set; }

        public int ClientCount { get; set; }

        public string OrderText { get; set; }
    }
}
