using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using System.Linq.Expressions;
using AutoMapper;
using System;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public UserDto GetUser(int userId)
        {
            var User = _unitOfWork.Users.GetBy(userId);
            return _mapper.Map<User, UserDto>(User);
        }

        public IEnumerable<UserDto> GetUsers(string searchString, string role)
        {
            Expression<Func<User, bool>> predicate = m => true;

            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(role))
            {
                predicate = m => m.Role == role && m.Username.Contains(searchString);
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                predicate = m => m.Username.Contains(searchString);
            }
            else if (!string.IsNullOrEmpty(role))
            {
                predicate = m => m.Role == role;
            }

            var users = _unitOfWork.Users.Find(predicate);

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public bool checkLogin(string userName, string passWord)
        {

            return _unitOfWork.Users.checkLoginUR(userName, passWord);
        }
        public IEnumerable<string> GetRoles()
        {
            return _unitOfWork.Users.GetRoles();
        }

        public void CreateUser(SaveUserDto saveUserDto)
        {
            var user = _mapper.Map<SaveUserDto, User>(saveUserDto);
            _unitOfWork.Users.Add(user);

            _unitOfWork.Complete();
        }

        public void UpdateUser(SaveUserDto saveUserDto)
        {
            var user = _unitOfWork.Users.GetBy(saveUserDto.UserId);
            if (user == null) return;

            _mapper.Map<SaveUserDto, User>(saveUserDto, user);

            _unitOfWork.Complete();
        }

        public void DeleteUser(int userId)
        {
            var user = _unitOfWork.Users.GetBy(userId);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                _unitOfWork.Complete();
            }
        }
    }
}