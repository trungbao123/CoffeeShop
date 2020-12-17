using RazorSample.ViewModels;

namespace RazorSample.Interfaces
{
    public interface IMaterialIndexVmService
    {
        MaterialIndexVm GetMaterialListVm(string searchString, string status, int pageIndex = 1);
    }
}