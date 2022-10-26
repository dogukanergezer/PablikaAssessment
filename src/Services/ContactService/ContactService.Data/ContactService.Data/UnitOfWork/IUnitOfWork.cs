
using ContactService.Data.Abstract;

namespace ContactService.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IContactRepository ContactRepository { get; }
        void Save();
    }
}
