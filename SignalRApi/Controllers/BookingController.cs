using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult BookingGet(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBooking)
        {
            Booking booking = new Booking()
            {
                Mail = createBooking.Mail,
                BookingTime = createBooking.BookingTime,
                Name = createBooking.Name,
                PersonCount = createBooking.PersonCount,
                Phone = createBooking.Phone,
                Description = createBooking.Description
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult BookingDelete(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi");
        }

        [HttpPut]
        public IActionResult BookingUpdate(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Mail = updateBookingDto.Mail,
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                BookingTime = updateBookingDto.BookingTime
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi");
        }


        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
    }
}
