using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        int TOrderTotalCount();
        int TActiveOrderCount();
        decimal TLastOrderTotalPrice();
        decimal TTodayTotalPrice();
        int TCompleteOrderCount();
    }
}
