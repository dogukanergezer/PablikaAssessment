using ContactService.Data.Abstract;
using ContactService.Data.Contexts;
using ContactService.Data.Repositories.Concrete.EntityFramework.Base;
using ContactService.Entity.Entities;

namespace ContactService.Data.Repositories.Concrete.EntityFramework
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ContactServiceContext _contactContext;
        public UserRepository(ContactServiceContext context) : base(context)
        {
            _contactContext = context;
        }


        public void AddUser(User user)
        {
            _contactContext.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _contactContext.Users.Remove(user);
        }

        public User GetUserByUserId(Guid userId) => _contactContext.Users.Where(x => x.Id == userId).FirstOrDefault();


        public List<User> GetAllUsers() => _contactContext.Users.ToList();
   

    }
}
