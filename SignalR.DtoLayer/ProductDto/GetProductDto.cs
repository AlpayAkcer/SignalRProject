namespace SignalR.DtoLayer.ProductDto
{
    public class GetProductDto
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
    }
}
