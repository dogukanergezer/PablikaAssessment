using AutoMapper;
using ContactService.Business.Abstract;
using ContactService.Data.Abstract;
using ContactService.Entity.DTOs;
using ContactService.Entity.Entities;

namespace ContactService.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactManager(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public void AddContact(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            _contactRepository.AddContact(contact);
        }

        public ContactDto GetContactByUserId(Guid userId)
        {
            var contactDto = _mapper.Map<ContactDto>(_contactRepository.GetContactByUserId(userId));
            return contactDto;

        }

        public List<ContactDto> GetAllContactsById(Guid userId)
        {
            List<ContactDto> contacts = _contactRepository.GetAllContactsById(userId).Where(x => x.UserId == userId).Select(y => new ContactDto
            {

                Id = y.Id,
                Email = y.Email,
                PhoneNumber = y.PhoneNumber,
                Address = y.Address,
                UserId = y.UserId


            }).ToList();

            return contacts;

        }

        public void DeleteContact(Guid contactId)
        {
            Contact contact = _contactRepository.GetContactById(contactId);
            _contactRepository.DeleteContact(contact);
        }
        public void DeleteContactByUserId(Guid userId)
        {
            Contact contact = _contactRepository.GetContactByUserId(userId);
            _contactRepository.DeleteContact(contact);
        }

        public List<int> PersonPhoneCount(string address)
        {
            return _contactRepository.PersonPhoneCount(address);
        }

    }
}
