using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetListContact()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetListContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContact)
        {
            _contactService.TAdd(new Contact()
            {
                Location = createContact.Location,
                Mail = createContact.Mail,
                Phone = createContact.Phone
            });
            return Ok("İletişim Kayıt Edildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("İletişim Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateContactList(UpdateContactDto updateContact)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = updateContact.ContactID,
                Location = updateContact.Location,
                Mail = updateContact.Mail,
                Phone = updateContact.Phone
            });
            return Ok("İletişim Güncellendi");
        }
    }
}
