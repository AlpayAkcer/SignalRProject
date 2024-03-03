using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAbout)
        {            
            _aboutService.TAdd(new About
            {
                Description = createAbout.Description,
                ImageUrl = createAbout.ImageUrl,
                Title = createAbout.Title
            });
            return Ok("Hakkında kısmı başarıyla eklendi ");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAbout)
        {           
            _aboutService.TUpdate(new About
            {
                AboutID = updateAbout.AboutID,
                Description = updateAbout.Description,
                ImageUrl = updateAbout.ImageUrl,
                Title = updateAbout.Title
            });
            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
