using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSample.Pages.Materials
{
    public class DetailsModel : PageModel
    {
        private readonly IMaterialService _service;

        public DetailsModel(IMaterialService service)
        {
            _service = service;
        }

        public MaterialDto Material { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = _service.GetMaterial(id ?? default(int));

            if (Material == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
