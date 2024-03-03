using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TChangeStatus(int id)
        {
            _notificationDal.ChangeStatus(id);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> TGetAllNotificationByFalse()
        {
            return _notificationDal.GetAllNotificationByFalse();
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetByID(id);
        }

        public List<Notification> TGetListAll()
        {
            return _notificationDal.GetListAll();
        }

        public int TNotificationCountByStatusFalse()
        {
            return _notificationDal.NotificationCountByStatusFalse();
        }

        public int TNotificationCountByStatusTrue()
        {
            return _notificationDal.NotificationCountByStatusTrue();
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
