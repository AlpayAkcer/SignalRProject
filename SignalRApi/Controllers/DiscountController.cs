using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscountList(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscountList(CreateDiscountDto createDiscount)
        {
            _discountService.TAdd(new Discount
            {
                Title = createDiscount.Title,
                Description = createDiscount.Description,
                Amount = createDiscount.Amount,
                ImageUrl = createDiscount.ImageUrl
            });
            return Ok("İndirim Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscountList(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim Silindi");
        }

        [HttpPut]
        public IActionResult UpdateDiscountList(UpdateDiscountDto updateDiscount)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountID = updateDiscount.DiscountID,
                Title = updateDiscount.Title,
                Description = updateDiscount.Description,
                Amount = updateDiscount.Amount,
                ImageUrl = updateDiscount.ImageUrl
            });
            return Ok("İndirim Güncellendi");
        }
    }
}

