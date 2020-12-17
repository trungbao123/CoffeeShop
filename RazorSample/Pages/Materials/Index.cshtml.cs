using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSample.Interfaces;
using RazorSample.ViewModels;
using Microsoft.AspNetCore.Http;

namespace RazorSample.Pages.Materials
{
    public class IndexModel : PageModel
    {
        private readonly IMaterialIndexVmService _materialService;

        public IndexModel(IMaterialIndexVmService materialService)
        {
            _materialService = materialService;

        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MaterialStatus { get; set; }

        public MaterialIndexVm MaterialIndexVM { get; set; }

        public void OnGet(string searchString, int pageIndex = 1)
        {
            MaterialIndexVM = _materialService.GetMaterialListVm(SearchString, MaterialStatus, pageIndex);
            /*if (string.IsNullOrEmpty(HttpContext.Session.GetString("IDUser")))
            {
                Response.Redirect("http://localhost:5000/Login");
            }*/
        }
    }
}
