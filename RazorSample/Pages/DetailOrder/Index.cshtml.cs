using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSample.Interfaces;
using RazorSample.ViewModels;
using Microsoft.AspNetCore.Http;

namespace RazorSample.Pages.DetailOrders
{
    public class IndexModel : PageModel
    {
        private readonly IDetailOrderIndexVmService _detailorderService;
        public IndexModel(IDetailOrderIndexVmService detailorderService)
        {
            _detailorderService = detailorderService;

        }
        [BindProperty(SupportsGet = true)]
        public string MenuName { get; set; }

        public DetailOrderIndexVm DetailOrderIndexVm { get; set; }

        public void OnGet(int pageIndex = 1)
        {
            DetailOrderIndexVm = _detailorderService.GetDetailOrderListVm(MenuName, pageIndex);
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IDUser")))
            {
                Response.Redirect("http://localhost:5000/Login");
            }
        }
    }
}
