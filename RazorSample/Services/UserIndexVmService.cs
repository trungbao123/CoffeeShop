using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorSample.Interfaces;
using RazorSample.ViewModels;

namespace RazorSample.Services
{
    public class UserIndexVmService : IUserIndexVmService
    {
        private int pageSize = 6;
        private readonly IUserService _service;

        public UserIndexVmService(IUserService UserService)
        {
            _service = UserService;
        }
        public bool checkLoginVm(string userName, string passWord)
        {
            return _service.checkLogin(userName, passWord);
        }
        public UserIndexVm GetUserListVm(string searchString, string role, int pageIndex)
        {
            var Users = _service.GetUsers(searchString, role);
            var roles = _service.GetRoles();

            return new UserIndexVm
            {
                Roles = new SelectList(roles),
                Users = PaginatedList<UserDto>.Create(Users, pageIndex, pageSize)
            };
        }
    }
}