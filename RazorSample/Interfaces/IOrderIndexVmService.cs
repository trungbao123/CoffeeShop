using RazorSample.ViewModels;

namespace RazorSample.Interfaces
{
    public interface IOrderIndexVmService
    {
        OrderIndexVm GetOrderListVm(string userName, int pageIndex = 1);
        int getIDod();
    }
}