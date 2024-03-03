using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new SignalRContext();
            return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SignalRContext();
            return context.Notifications.Where(x => x.Status == false).Count();
        }

        public int NotificationCountByStatusTrue()
        {
            using var context = new SignalRContext();
            return context.Notifications.Where(x => x.Status == true).Count();
        }

        public void ChangeStatus(int id)
        {
            using var context = new SignalRContext();
            var status = context.Notifications.Find(id);
            if (status.Status == true)
            {
                status.Status = false;
            }
            else
            {
                status.Status = true;
            }
            context.SaveChanges();
        }
    }
}
