using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorSample.Pages.DetailOrders
{
    public class EditModel : PageModel
    {
        private readonly IDetailOrderService _service;
        private readonly IMapper _mapper;

        public EditModel(IDetailOrderService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [BindProperty]
        public SaveDetailOrderDto DetailOrder { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailorder = _service.GetDetailOrder(id ?? default(int));

            if (detailorder == null)
            {
                return NotFound();
            }

            DetailOrder = _mapper.Map<DetailOrderDto, SaveDetailOrderDto>(detailorder);

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
                _service.UpdateDetailOrder(DetailOrder);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailOrderExists(DetailOrder.DetailOrderId))
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
        private bool DetailOrderExists(int id)
        {
            return _service.GetDetailOrder(id) != null;
        }

    }
}
