using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSample.Interfaces;
using RazorSample.ViewModels;
using Microsoft.AspNetCore.Http;

namespace RazorSample.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserIndexVmService _userService;

        public IndexModel(IUserIndexVmService userService)
        {
            _userService = userService;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserRole { get; set; }

        public UserIndexVm UserIndexVM { get; set; }

        public void OnGet(string searchString, int pageIndex = 1)
        {
            UserIndexVM = _userService.GetUserListVm(SearchString, UserRole, pageIndex);
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IDUser")))
            {
                Response.Redirect("http://localhost:5000/Login");
            }
        }
    }
}
