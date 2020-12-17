using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSample.Interfaces;
using RazorSample.ViewModels;
using Microsoft.AspNetCore.Http;

namespace RazorSample.Pages.Menus
{
    public class IndexModel : PageModel
    {
        private readonly IMenuIndexVmService _menuService;

        public IndexModel(IMenuIndexVmService menuService)
        {
            _menuService = menuService;

        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MenuGenre { get; set; }

        public MenuIndexVm MenuIndexVM { get; set; }

        public void OnGet(string searchString, int pageIndex = 1)
        {
            MenuIndexVM = _menuService.GetMenuListVm(SearchString, MenuGenre, pageIndex);
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IDUser")))
            {
                Response.Redirect("http://localhost:5000/Login");
            }
        }
    }
}
