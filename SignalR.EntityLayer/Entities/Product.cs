namespace SignalR.EntityLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFeatured { get; set; } = false;
        public bool IsSpecial { get; set; } = false;
        public bool Status { get; set; } = true;
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}
