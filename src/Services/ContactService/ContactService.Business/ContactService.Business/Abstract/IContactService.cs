using ContactService.Entity.DTOs;

namespace ContactService.Business.Abstract
{
    public interface IContactService
    {
        void AddContact(ContactDto contactDto);
        void DeleteContact(Guid contactId);
        void DeleteContactByUserId(Guid userId);
        ContactDto GetContactByUserId(Guid userId);
        List<ContactDto> GetAllContactsById(Guid userId);
        List<int> PersonPhoneCount(string address);

    }
}
