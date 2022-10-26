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
        public Contact ConvertToContact(ContactDto contactDto)
        {
            Contact contact = new Contact();
            contact.UserId = contactDto.UserId;
            contact.PhoneNumber = contactDto.PhoneNumber;
            contact.Email = contactDto.Email;
            contact.Address = contactDto.Address.ToUpper().ToLower();

            return contact;
        }
        public ContactDto ConvertToContactDto(Contact contact)
        {
            ContactDto contactDto = new ContactDto();
            try
            {

                contactDto.UserId = contact.UserId;
                contactDto.PhoneNumber = contact.PhoneNumber;
                contactDto.Email = contact.Email;
                contactDto.Address = contact.Address;
            }
            catch
            {
                contactDto = null;
            }


            return contactDto;
        }
        public void AddContact(ContactDto contactDto)
        {
            Contact contact = ConvertToContact(contactDto);
            uow.ContactRepository.AddContact(contact);
            uow.Save();
        }

        public ContactDto GetContactByUserId(Guid userId)
        {
            ContactDto contactDto = ConvertToContactDto(uow.ContactRepository.GetContactByUserId(userId));
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
