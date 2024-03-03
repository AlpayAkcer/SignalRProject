using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;
        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var value = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                Name = createMenuTableDto.Name,
                Status = createMenuTableDto.Status
            };
            _menuTableService.TAdd(menuTable);
            return Ok("Masa başarıyla eklendi ");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                Name = updateMenuTableDto.Name,
                Status = updateMenuTableDto.Status
            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }
    }
}
