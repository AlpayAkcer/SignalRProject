using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProduct)
        {
            _productService.TAdd(new Product
            {
                ProductName = createProduct.ProductName,
                Description = createProduct.Description,
                ImageUrl = createProduct.ImageUrl,
                IsFeatured = createProduct.IsFeatured,
                IsSpecial = createProduct.IsSpecial,
                Price = createProduct.Price,
                CategoryID = createProduct.CategoryID,
                Status = true,
            });
            return Ok("Ürün eklendi ");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProduct)
        {
            _productService.TUpdate(new Product
            {
                ProductID = updateProduct.ProductID,
                ProductName = updateProduct.ProductName,
                Description = updateProduct.Description,
                ImageUrl = updateProduct.ImageUrl,
                IsFeatured = updateProduct.IsFeatured,
                IsSpecial = updateProduct.IsSpecial,
                CategoryID = updateProduct.CategoryID,
                Price = updateProduct.Price,
                Status = true,
            });
            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            //var value = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            //return Ok(value);

            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(p => new ResultProductWithCategory
            {
                CategoryName = p.Category.CategoryName,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                IsFeatured = p.IsFeatured,
                IsSpecial = p.IsSpecial,
                Price = p.Price,
                Status = p.Status,
                ProductName = p.ProductName,
                ProductID = p.ProductID
            });
            return Ok(values.ToList());
        }


        //Business Katmanındaki Methodlar
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }

        [HttpGet("ProductNamePriceByMax")]
        public IActionResult ProductNamePriceByMax()
        {
            return Ok(_productService.TProductNamePriceByMax());
        }

        [HttpGet("ProductNamePriceByMin")]
        public IActionResult ProductNamePriceByMin()
        {
            return Ok(_productService.TProductNamePriceByMin());
        }

        [HttpGet("ProductPriceByCategory")]
        public IActionResult ProductPriceByCategory()
        {
            return Ok(_productService.TProductPriceByCategory());
        }

    }
}
