namespace SignalRApi.Models
{
    public class ResultBasketListWithProducts
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
    }
}
