using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorSample.Pages.Materials
{
    public class EditModel : PageModel
    {
        private readonly IMaterialService _service;
        private readonly IMapper _mapper;

        public EditModel(IMaterialService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [BindProperty]
        public SaveMaterialDto Material { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = _service.GetMaterial(id ?? default(int));

            if (material == null)
            {
                return NotFound();
            }

            Material = _mapper.Map<MaterialDto, SaveMaterialDto>(material);

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                _service.UpdateMaterial(Material);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(Material.MaterialId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }
        private bool MaterialExists(int id)
        {
            return _service.GetMaterial(id) != null;
        }

    }
}
