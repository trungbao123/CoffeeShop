using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IDetailOrderRepository : IRepository<DetailOrder>
    {
        IEnumerable<string> GetMenuNames();
    }
}