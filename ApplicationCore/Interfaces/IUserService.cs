using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        UserDto GetUser(int userId);
        IEnumerable<UserDto> GetUsers(string searchString, string role);
        IEnumerable<string> GetRoles();
        bool checkLogin(string userName, string passWord);
        void CreateUser(SaveUserDto userDto);
        void UpdateUser(SaveUserDto userDto);
        void DeleteUser(int userId);
    }
}