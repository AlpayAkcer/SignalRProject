using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        public int TProductCount();
        decimal TProductPriceAvg();
        string TProductNamePriceByMax();
        string TProductNamePriceByMin();
        decimal TProductPriceByCategory();
    }
}
