using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(nameof(ShopInfo))]
    public class ShopInfo
    {
        public int ShopInfoId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User Owner { get; set; }

        public virtual ICollection<EventInfo> Events { get; set; }
        public virtual ICollection<ShopReview> Reviews { get; set; }
        public IEnumerable<ShopInfo> ShopName { get; set; }
        //Адреса с номером телефона
    }
}
