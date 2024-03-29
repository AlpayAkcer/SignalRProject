﻿namespace SignalRWebUI.DtoViewModels.ProductDto
{
    public class ResultProductWithCategory
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSpecial { get; set; }
        public bool Status { get; set; }
    }
}
