using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{

    public class OrderEntity
    {
        [Key]
        public int OrderId { get; set; }

        public string Status { get; set; }

        public int Table {  get; set; }

        public int ClientCount { get; set; }

        public string OrderText { get; set; }
    }
}
