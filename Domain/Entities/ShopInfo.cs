using System.Collections.Generic;

namespace Domain.Entities
{
    public class ShopInfo
    {
        public int ShopInfoId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User Owner { get; set; }

        public virtual ICollection<EventInfo> Events { get; set; }
        public virtual ICollection<ShopReview> Reviews { get; set; }
    }
}
