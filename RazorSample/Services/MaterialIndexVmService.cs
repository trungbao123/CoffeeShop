using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorSample.Interfaces;
using RazorSample.ViewModels;

namespace RazorSample.Services
{
    public class MaterialIndexVmService : IMaterialIndexVmService
    {
        private int pageSize = 6;
        private readonly IMaterialService _service;

        public MaterialIndexVmService(IMaterialService materialService)
        {
            _service = materialService;
        }

        public MaterialIndexVm GetMaterialListVm(string searchString, string status, int pageIndex)
        {
            var materials = _service.GetMaterials(searchString, status);
            var statuses = _service.GetStatuses();

            return new MaterialIndexVm
            {
                Statuses = new SelectList(statuses),
                Materials = PaginatedList<MaterialDto>.Create(materials, pageIndex, pageSize)
            };
        }
    }
}