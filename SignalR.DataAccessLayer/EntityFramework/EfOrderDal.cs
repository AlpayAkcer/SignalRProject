using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            var context = new SignalRContext();
            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public int CompleteOrderCount()
        {
            var context = new SignalRContext();
            return context.Orders.Where(x => x.Description == "Hesap Kapatıldı").Count();
        }

        public decimal LastOrderTotalPrice()
        {
            var context = new SignalRContext();
            return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(p => p.TotalPrice).FirstOrDefault();
        }

        public int OrderTotalCount()
        {
            var context = new SignalRContext();
            return context.Orders.Count();
        }

        public decimal TodayTotalPrice()
        {
            var context = new SignalRContext();
            return context.Orders.Where(x => x.OrderDate == DateTime.Today).Sum(x => x.TotalPrice);
        }
    }
}
