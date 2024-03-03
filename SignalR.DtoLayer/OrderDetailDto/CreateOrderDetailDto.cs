namespace SignalR.DtoLayer.OrderDetailDto
{
    public class CreateOrderDetailDto
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
    }
}
