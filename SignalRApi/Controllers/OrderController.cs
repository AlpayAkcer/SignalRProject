using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TOrderTotalCount());
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpGet("LastOrderTotalPrice")]
        public IActionResult LastOrderTotalPrice()
        {
            return Ok(_orderService.TLastOrderTotalPrice());
        }

        [HttpGet("TodayOrderTotalPrice")]
        public IActionResult TodayOrderTotalPrice()
        {
            return Ok(_orderService.TTodayTotalPrice());
        }

        [HttpGet("CompleteOrderCount")]
        public IActionResult CompleteOrderCount()
        {
            return Ok(_orderService.TCompleteOrderCount());
        }
    }
}
