using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorSample.ViewModels
{
    public class MaterialIndexVm
    {
            public SelectList Statuses { get; set; }
            public PaginatedList<MaterialDto> Materials { get; set; }
    }
}