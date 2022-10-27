using ContactService.Business.Abstract;
using ContactService.Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IContactService _contactService;
        public ContactController(IUserService userService, IContactService contactService)
        {
            _userService = userService;
            _contactService = contactService;
        }

        [HttpPost]
        public void AddUser(UserDto userDto)
        {
            userDto.UserId = Guid.NewGuid(); 
            _userService.AddUser(userDto);
        }
        [HttpDelete]
        public void DeleteUser(UserDto userDto)
        {
            _contactService.DeleteContactByUserId(userDto.UserId);
            _userService.DeleteUser(userDto.UserId);

        }
        [HttpPost]

        public void DeleteContact(ContactDto contactDto)
        {
            _contactService.DeleteContact(contactDto.Id);
        }

        [HttpPost]
        public void AddContact(ContactDto contactDto)
        {
            _contactService.AddContact(contactDto);
        }

        [HttpGet]
        public List<UserDto> GetAllUsersContacts() => _userService.GetAllUsersContacts();


        [HttpPost]
        public List<ContactDto> GetContact(ContactDto contactDto) => _contactService.GetAllContactsById(contactDto.UserId);


        [HttpPost]
        public ReportDto CreateReport(ContactDto contactDto)
        {
            List<int> counts = _contactService.PersonPhoneCount(contactDto.Address);
            ReportDto reportDto = new ReportDto();
            reportDto.Location = contactDto.Address;
            reportDto.UserCount = counts[0];
            reportDto.PhoneCount = counts[1];

            return reportDto;
        }

    }
}
