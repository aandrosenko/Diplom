using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(nameof(EventInfo))]
    public class EventInfo
    {
        public int EventInfoId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string LogoUrl { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ShopInfoId { get; set; }
        public ShopInfo ShopInfo { get; set; }

        public virtual ICollection<EventReview> Reviews { get; set; }
    }
}
