using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryList(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCategoryList(CreateCategoryDto createCategory)
        {
            _categoryService.TAdd(new Category
            {
                CategoryName = createCategory.CategoryName,
                Status = true
            });
            return Ok("Kategori Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryList(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategoryList(UpdateCategoryDto updateCategory)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryName = updateCategory.CategoryName,
                CategoryID = updateCategory.CategoryID,
                Status = true
            });
            return Ok("Kategori Güncellendi");
        }

        //Business Katmanındaki methodlar
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_categoryService.TActiveCategory());
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_categoryService.TPassiveCategory());
        }
    }
}
