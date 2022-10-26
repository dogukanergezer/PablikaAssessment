using ContactService.Data.Abstract.Base;
using ContactService.Entity.Entities;

namespace ContactService.Data.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        void AddUser(User user);
        User GetUserByUserId(Guid userId);
        void DeleteUser(User user);
        List<User> GetAllUsers();

    }
}
