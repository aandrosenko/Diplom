using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class EventReviewModel
    {
        public int EventReviewId { get; set; }
        public int UserId { get; set; }
        public int EventInfoId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public User User { get; set; }
        public EventInfo EventInfo { get; set; }

        public IEnumerable<EventReview> EventReviews { get; set; }
    }
}