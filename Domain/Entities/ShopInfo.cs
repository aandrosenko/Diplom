namespace Domain.Entities
{
    public class ShopInfo
    {
        public int ShopInfoId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User Owner { get; set; }
    }
}
