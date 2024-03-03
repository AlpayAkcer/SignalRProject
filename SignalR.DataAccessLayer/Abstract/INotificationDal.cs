using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        //Bildirim okunmadı olanı
        int NotificationCountByStatusFalse();
        int NotificationCountByStatusTrue();
        List<Notification> GetAllNotificationByFalse();
        void ChangeStatus(int id);
    }
}
