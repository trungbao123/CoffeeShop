using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSample.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderService _service;

        public DeleteModel(IOrderService service)
        {
            _service = service;
        }

        [BindProperty]
        public OrderDto Order { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = _service.GetOrder(id ?? default(int));

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _service.DeleteOrder(id ?? default(int));

            return RedirectToPage("./Index");
        }
    }
}
