using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult TChangeStatus(int id)
        {
            _notificationService.TChangeStatus(id);
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatus()
        {
            var value = _notificationService.TNotificationCountByStatusFalse();
            return Ok(value);
        }

        [HttpGet("NotificationCountByStatusTrue")]
        public IActionResult NotificationCountByStatusTrue()
        {
            var value = _notificationService.TNotificationCountByStatusTrue();
            return Ok(value);
        }


        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new Notification()
            {
                Type = createNotificationDto.Type,
                Description = createNotificationDto.Description,
                Status = false,
                Icon = createNotificationDto.Icon,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };
            _notificationService.TAdd(notification);
            return Ok("Kayıt Yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult NotificationDelete(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Kayıt Silindi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification()
            {
                NotificationID = updateNotificationDto.NotificationID,
                Type = updateNotificationDto.Type,
                Description = updateNotificationDto.Description,
                Status = updateNotificationDto.Status,
                Icon = updateNotificationDto.Icon,
                Date = DateTime.Now
            };
            _notificationService.TUpdate(notification);
            return Ok("Kayıt Güncellendi");
        }
    }
}
