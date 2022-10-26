using ContactService.Data.Abstract.Base;
using ContactService.Entity.Entities;

namespace ContactService.Data.Abstract
{
    public interface IContactRepository : IRepository<Contact>
    {
        void AddContact(Contact contact);
        Contact GetContactByUserId(Guid userId);
        Contact GetContactById(Guid contactId);
        void DeleteContact(Contact contact);
        List<Contact> GetAllContacts();
        List<Contact> GetAllContactsById(Guid userId);

        List<int> PersonPhoneCount(string address);
    }
}
