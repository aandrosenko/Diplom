using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(nameof(EventReview))]
    public class EventReview
    {
        public int EventReviewId { get; set; }
        public int UserId { get; set; }
        public int EventInfoId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public User User { get; set; }
        public EventInfo EventInfo { get; set; }
    }
}
