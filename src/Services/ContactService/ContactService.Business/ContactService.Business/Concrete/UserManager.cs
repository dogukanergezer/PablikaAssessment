using AutoMapper;
using ContactService.Business.Abstract;
using ContactService.Data.Abstract;
using ContactService.Entity.DTOs;
using ContactService.Entity.Entities;

namespace ContactService.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IMapper mapper, IUserRepository userRepository, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _contactRepository = contactRepository;
        }
        public void AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userRepository.AddUser(user);
        }
        public void DeleteUser(Guid userId)
        {
            User user = _userRepository.GetUserByUserId(userId);
            _userRepository.DeleteUser(user);
        }

        public List<UserDto> GetAllUsersContacts()
        {
            List<UserDto> userDtos = _userRepository.GetAllUsers().Select(x => new UserDto
            {
                UserId = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                CompanyName = x.CompanyName

            }).ToList();

            var usersIDs = userDtos.Select(x => x.UserId).ToList();

            var contactsDtos = _contactRepository.GetAllContacts().Where(x => usersIDs.Contains(x.UserId)).Select(y => new ContactDto
            {
                Id = y.Id,
                Email = y.Email,
                PhoneNumber = y.PhoneNumber,
                Address = y.Address,
                UserId = y.UserId

            }).ToList();


            foreach (var item in userDtos)
            {
                item.ContactDtos = contactsDtos.Where(x => x.UserId == item.UserId).ToList();

            }

            return userDtos;
        }
    }
}
