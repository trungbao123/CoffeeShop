using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        IEnumerable<string> GetStatuses();
    }
}