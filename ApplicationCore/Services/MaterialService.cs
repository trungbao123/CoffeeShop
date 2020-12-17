using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaterialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public MaterialDto GetMaterial(int materialId)
        {
            var material = _unitOfWork.Materials.GetBy(materialId);
            return _mapper.Map<Material, MaterialDto>(material);
        }

        public IEnumerable<MaterialDto> GetMaterials(string searchString, string status)
        {
            Expression<Func<Material, bool>> predicate = m => true;

            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(status))
            {
                predicate = m => m.Status == status && m.MaterialName.Contains(searchString);
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                predicate = m => m.MaterialName.Contains(searchString);
            }
            else if (!string.IsNullOrEmpty(status))
            {
                predicate = m => m.Status == status;
            }

            var materials = _unitOfWork.Materials.Find(predicate);

            return _mapper.Map<IEnumerable<Material>, IEnumerable<MaterialDto>>(materials);
        }

        public IEnumerable<string> GetStatuses()
        {
            return _unitOfWork.Materials.GetStatuses();
        }

        public void CreateMaterial(SaveMaterialDto saveMaterialDto)
        {
            var material = _mapper.Map<SaveMaterialDto, Material>(saveMaterialDto);
            _unitOfWork.Materials.Add(material);

            _unitOfWork.Complete();
        }

        public void UpdateMaterial(SaveMaterialDto saveMaterialDto)
        {
            var material = _unitOfWork.Materials.GetBy(saveMaterialDto.MaterialId);
            if (material == null) return;

            _mapper.Map<SaveMaterialDto, Material>(saveMaterialDto, material);

            _unitOfWork.Complete();
        }

        public void DeleteMaterial(int materialId)
        {
            var material = _unitOfWork.Materials.GetBy(materialId);
            if (material != null)
            {
                _unitOfWork.Materials.Remove(material);
                _unitOfWork.Complete();
            }
        }
    }
}