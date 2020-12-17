using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<string> GetUsers();
        int getIDod();
    }
}