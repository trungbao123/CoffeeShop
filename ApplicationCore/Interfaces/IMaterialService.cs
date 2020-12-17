using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IMaterialService
    {
        MaterialDto GetMaterial(int materialId);
        IEnumerable<MaterialDto> GetMaterials(string searchString, string status);
        IEnumerable<string> GetStatuses();
        void CreateMaterial(SaveMaterialDto materialDto);
        void UpdateMaterial(SaveMaterialDto materialDto);
        void DeleteMaterial(int materialId);
    }
}