using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var value = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(value);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var value = context.Baskets.Include(x => x.Product).Where(p => p.MenuTableID == id).Select(l => new ResultBasketListWithProducts
            {
                BasketID = l.BasketID,
                MenuTableID = l.MenuTableID,
                ProductID = l.ProductID,
                ProductName = l.Product.ProductName,
                Quantity = l.Quantity,
                UnitPrice = l.UnitPrice,
                TotalPrice = l.TotalPrice
            }).ToList();
            return Ok(value);
        }


        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto basketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket
            {
                ProductID = basketDto.ProductID,
                Quantity = 1,
                MenuTableID = 3,
                UnitPrice = context.Products.Where(x => x.ProductID == basketDto.ProductID).Select(p => p.Price).FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}
