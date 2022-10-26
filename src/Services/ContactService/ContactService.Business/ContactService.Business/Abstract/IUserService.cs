using ContactService.Entity.DTOs;

namespace ContactService.Business.Abstract
{
    public interface IUserService
    {
        void AddUser(UserDto userDto);

        void DeleteUser(Guid userId);
        List<UserDto> GetAllUsersContacts();

    }
}
