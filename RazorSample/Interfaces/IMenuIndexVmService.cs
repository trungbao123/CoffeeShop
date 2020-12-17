using RazorSample.ViewModels;

namespace RazorSample.Interfaces
{
    public interface IMenuIndexVmService
    {
        MenuIndexVm GetMenuListVm(string searchString, string genre, int pageIndex = 1);
        int getIDod();
    }
}