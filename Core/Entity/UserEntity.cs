using Core.Const;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name:"users")]
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }

        public string FIO { get; set; }

        public string Role { get; set; }

        public List<int>? ShiftIDs { get; set; } = new() { };

        public string Status { get; set; } = StatusConst.UserWork;

        public string Password { get; set; }
    }
}
