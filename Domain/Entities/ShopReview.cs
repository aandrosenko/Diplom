using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(nameof(ShopReview))]
    public class ShopReview
    {
        public int ShopReviewId { get; set; }
        public int UserId { get; set; }
        public int ShopInfoId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public User User { get; set; }
        public ShopInfo Shop { get; set; }
    }
}
