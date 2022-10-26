﻿using ContactService.Data.Contexts;
using ContactService.Data.UnitOfWork;
using ContactService.Entity.Entities;
using ContactService.Business.Abstract;
using ContactService.Entity.DTOs;

namespace ContactService.Business.Concrete
{
    public class UserManager : IUserService
    {
        UnitOfWork uow = new UnitOfWork(new ContactServiceContext());

        public User ConvertToUser(UserDto userDto)
        {
            User user = new User();
            user.Id = userDto.UserId;
            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.CompanyName = userDto.CompanyName;
            return user;
        }
        public void AddUser(UserDto userDto)
        {
            User user = ConvertToUser(userDto);
            uow.UserRepository.AddUser(user);
            uow.Save();
        }
        public void DeleteUser(Guid userId)
        {
            User user = uow.UserRepository.GetUserByUserId(userId);
            uow.UserRepository.DeleteUser(user);
            uow.Save();
        }

        public List<UserDto> GetAllUsersContacts()
        {
            List<UserDto> userDtos = uow.UserRepository.GetAllUsers().Select(x => new UserDto
            {
                UserId = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                CompanyName = x.CompanyName

            }).ToList();

            var usersIDs = userDtos.Select(x => x.UserId).ToList();

            var contactsDtos = uow.ContactRepository.GetAllContacts().Where(x => usersIDs.Contains(x.UserId)).Select(y => new ContactDto
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