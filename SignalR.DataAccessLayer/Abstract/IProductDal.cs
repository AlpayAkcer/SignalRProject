using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();
        decimal ProductPriceAvg();
        string ProductNamePriceByMax();
        string ProductNamePriceByMin();
        decimal ProductPriceByCategory();
    }
}
