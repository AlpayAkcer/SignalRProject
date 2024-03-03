using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public Order TGetById(int id)
        {
            return _orderDal.GetByID(id);
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public void TAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }

        //api katmanının işlemleri
        public int TOrderTotalCount()
        {
            return _orderDal.OrderTotalCount();
        }

        public int TActiveOrderCount()
        {
            return _orderDal.ActiveOrderCount();
        }

        public decimal TLastOrderTotalPrice()
        {
            return _orderDal.LastOrderTotalPrice();
        }

        public decimal TTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }

        public int TCompleteOrderCount()
        {
            return _orderDal.CompleteOrderCount();
        }
    }
}
