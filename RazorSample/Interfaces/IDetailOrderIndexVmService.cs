using RazorSample.ViewModels;

namespace RazorSample.Interfaces
{
    public interface IDetailOrderIndexVmService
    {
        DetailOrderIndexVm GetDetailOrderListVm(string MenuName, int pageIndex = 1);
    }
}