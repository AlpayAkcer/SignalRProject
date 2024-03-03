using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product TGetById(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }

        public string TProductNamePriceByMax()
        {
            return _productDal.ProductNamePriceByMax();
        }

        public string TProductNamePriceByMin()
        {
            return _productDal.ProductNamePriceByMin();
        }

        public decimal TProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public decimal TProductPriceByCategory()
        {
            return _productDal.ProductPriceByCategory();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
