using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorSample.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public EditModel(IOrderService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [BindProperty]
        public SaveOrderDto Order { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _service.GetOrder(id ?? default(int));

            if (order == null)
            {
                return NotFound();
            }

            Order = _mapper.Map<OrderDto, SaveOrderDto>(order);

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
                _service.UpdateOrder(Order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.OrderId))
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
        private bool OrderExists(int id)
        {
            return _service.GetOrder(id) != null;
        }

    }
}
