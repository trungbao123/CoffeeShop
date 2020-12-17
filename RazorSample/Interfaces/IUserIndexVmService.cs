using RazorSample.ViewModels;

namespace RazorSample.Interfaces
{
    public interface IUserIndexVmService
    {
        UserIndexVm GetUserListVm(string searchString, string role, int pageIndex = 1);
        bool checkLoginVm(string userName, string passWord);
    }
}