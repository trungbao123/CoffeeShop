using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<string> GetRoles();
        bool checkLoginUR(string userName, string passWord);
    }
}