using ContactService.Data.Abstract;
using ContactService.Data.Contexts;
using ContactService.Data.Repositories.Concrete.EntityFramework.Base;
using ContactService.Entity.Entities;

namespace ContactService.Data.Repositories.Concrete.EntityFramework
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private ContactServiceContext _contactContext;
        public ContactRepository(ContactServiceContext context) : base(context)
        {
            _contactContext = context;
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
        }
        public Contact GetContactByUserId(Guid userId)
        {
            Contact contact = _contactContext.Contacts.FirstOrDefault(x => x.UserId == userId);
            return contact;
        }
        public Contact GetContactById(Guid contactId)
        {
            Contact contact = _contactContext.Contacts.FirstOrDefault(x => x.Id == contactId);
            return contact;
        }
        public void DeleteContact(Contact contact)
        {
            try
            {
                _contactContext.Contacts.Remove(contact);
            }
            catch
            {

            }

        }
        public List<Contact> GetAllContacts()
        {
            return _contactContext.Contacts.ToList();
        }


        public List<Contact> GetAllContactsById(Guid userId)
        {
            return _contactContext.Contacts.ToList();
        }


        public List<int> PersonPhoneCount(string address)
        {
            List<int> counts = new List<int>();

            int userCount = _context.Contacts.Where(x => x.Address == address.ToUpper().ToLower()).Select(x => x.UserId).ToList().Distinct().Count();
            counts.Add(userCount);

            int phoneCount = _context.Contacts.Where(x => x.Address == address).Select(x => x.PhoneNumber).ToList().Count();
            counts.Add(phoneCount);

            return counts;
        }
    }
}
