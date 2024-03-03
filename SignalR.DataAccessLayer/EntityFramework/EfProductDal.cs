using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public string ProductNamePriceByMax()
        {
            var context = new SignalRContext();
            return context.Products.Where(x => x.Price == (context.Products.Max(x => x.Price))).Select(p => p.ProductName).FirstOrDefault();
        }

        public string ProductNamePriceByMin()
        {
            var context = new SignalRContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(x => x.Price))).Select(p => p.ProductName + "-" + p.Price.ToString("C")).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            var context = new SignalRContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductPriceByCategory()
        {
            var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(p => p.CategoryID).FirstOrDefault())).Average(x => x.Price);
        }
    }
}
