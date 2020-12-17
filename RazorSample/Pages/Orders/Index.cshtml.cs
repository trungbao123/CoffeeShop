using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSample.Interfaces;
using RazorSample.ViewModels;
using Microsoft.AspNetCore.Http;

namespace RazorSample.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderIndexVmService _orderService;
        public IndexModel(IOrderIndexVmService orderService)
        {
            _orderService = orderService;

        }
        [BindProperty(SupportsGet = true)]
        public string userName { get; set; }

        public OrderIndexVm OrderIndexVm { get; set; }

        public void OnGet(int pageIndex = 1)
        {
            OrderIndexVm = _orderService.GetOrderListVm(userName, pageIndex);
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IDUser")))
            {
                Response.Redirect("http://localhost:5000/Login");
            }
        }
    }
}
