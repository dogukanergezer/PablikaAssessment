using AutoMapper;
using ContactService.Business.Abstract;
using ContactService.Data.Contexts;
using ContactService.Data.UnitOfWork;
using ContactService.Entity.DTOs;
using ContactService.Entity.Entities;

namespace ContactService.Business.Concrete
{
    public class ContactManager : IContactService
    {
        UnitOfWork uow = new UnitOfWork(new ContactServiceContext());
        private readonly IMapper _mapper;

        public ContactManager(IMapper mapper)
        {
            _mapper = mapper;
        }
       
        public void AddContact(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            uow.ContactRepository.AddContact(contact);
            uow.Save();
        }

        public ContactDto GetContactByUserId(Guid userId)
        {
            var contactDto = _mapper.Map<ContactDto>(uow.ContactRepository.GetContactByUserId(userId));
            return contactDto;

        }

        public List<ContactDto> GetAllContactsById(Guid userId)
        {
            List<ContactDto> contacts = uow.ContactRepository.GetAllContactsById(userId).Where(x => x.UserId == userId).Select(y => new ContactDto
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
            Contact contact = uow.ContactRepository.GetContactById(contactId);
            uow.ContactRepository.DeleteContact(contact);
            uow.Save();
        }
        public void DeleteContactByUserId(Guid userId)
        {
            Contact contact = uow.ContactRepository.GetContactByUserId(userId);
            uow.ContactRepository.DeleteContact(contact);
            uow.Save();
        }

        public List<int> PersonPhoneCount(string address)
        {
            return uow.ContactRepository.PersonPhoneCount(address);
        }

    }
}
