using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        int OrderTotalCount();
        int ActiveOrderCount();
        decimal LastOrderTotalPrice();
        decimal TodayTotalPrice();
        int CompleteOrderCount();
    }
}
