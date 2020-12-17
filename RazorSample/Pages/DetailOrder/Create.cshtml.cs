using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace RazorSample.Pages.DetailOrder
{
    public class CreateModel : PageModel
    {
        private readonly IDetailOrderService _service;

        public CreateModel(IDetailOrderService service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public decimal Price { get; set; }
        public IActionResult OnGet(int? price)
        {
            Price = price ?? default(decimal);
            return Page();
        }

        [BindProperty]
        public SaveDetailOrderDto DetailOrder { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.CreateDetailOrder(DetailOrder);

            return RedirectToPage("Index");
        }
    }
}
