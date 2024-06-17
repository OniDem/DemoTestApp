namespace Core.DTO.Order
{
    public class ChangeOrderStatusRequest
    {
        public int OrderId { get; set; }

        public string Status { get; set; }
    }
}
