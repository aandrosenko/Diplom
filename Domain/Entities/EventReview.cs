using System;

namespace Domain.Entities
{
    public class EventReview
    {
        public int EventReviewId { get; set; }
        public int UserId { get; set; }
        public int EventInfoId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }

        public User User { get; set; }
        public EventInfo Event { get; set; }
    }
}
