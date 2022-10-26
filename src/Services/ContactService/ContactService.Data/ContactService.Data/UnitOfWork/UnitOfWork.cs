using ContactService.Data.Abstract;
using ContactService.Data.Contexts;
using ContactService.Data.Repositories.Concrete.EntityFramework;

namespace ContactService.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private ContactServiceContext _contactContext;
        public UnitOfWork(ContactServiceContext context)
        {
            _contactContext = context;
            UserRepository = new UserRepository(_contactContext);
            ContactRepository = new ContactRepository(_contactContext);
        }

        public IUserRepository UserRepository { get; private set; }

        public IContactRepository ContactRepository { get; private set; }
        public void Save()
        {
            _contactContext.SaveChanges();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
