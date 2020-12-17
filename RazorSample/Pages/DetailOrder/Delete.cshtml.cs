using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSample.Pages.DetailOrders
{
    public class DeleteModel : PageModel
    {
        private readonly IDetailOrderService _service;

        public DeleteModel(IDetailOrderService service)
        {
            _service = service;
        }

        [BindProperty]
        public DetailOrderDto DetailOrder { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DetailOrder = _service.GetDetailOrder(id ?? default(int));

            if (DetailOrder == null)
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

            _service.DeleteDetailOrder(id ?? default(int));

            return RedirectToPage("./Index");
        }
    }
}
