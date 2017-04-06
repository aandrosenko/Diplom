using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class EventInfo
    {
        public int EventInfoId { get; set; }
        public string Text { get; set; }                
        public DateTime DateTimeBegin { get; set; }   
        public int ShopInfoId { get; set; }
        public ShopInfo Shop { get; set; }

        public virtual ICollection<EventReview> Reviews { get; set; }
    }
}
