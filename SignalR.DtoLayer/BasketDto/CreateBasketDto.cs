namespace SignalR.DtoLayer.BasketDto
{
    public class CreateBasketDto
    {
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
