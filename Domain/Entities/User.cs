using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsRemoved { get; set; }

        public virtual ICollection<ShopInfo> Shops { get; set; }
    }
}
