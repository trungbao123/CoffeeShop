using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSample.Pages.Menus
{
    public class DeleteModel : PageModel
    {
        private readonly IMenuService _service;

        public DeleteModel(IMenuService service)
        {
            _service = service;
        }

        [BindProperty]
        public MenuDto Menu { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu = _service.GetMenu(id ?? default(int));

            if (Menu == null)
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

            _service.DeleteMenu(id ?? default(int));

            return RedirectToPage("./Index");
        }
    }
}
