using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CoffeeShopContext context) : base(context)
        {
        }

        public IEnumerable<string> GetRoles()
        {
            var roles = from m in CoffeeShopContext.Users
                        orderby m.Role
                        select m.Role;

            return roles.Distinct().ToList();
        }
        public bool checkLoginUR(string userName, string passWord)
        {
            var users = from m in CoffeeShopContext.Users
                        select m;
            foreach (var item in users)
            {
                if (item.Username.Equals(userName) && item.Password.Equals(passWord))
                {
                    return true;
                }
            }
            return false;
        }
        protected CoffeeShopContext CoffeeShopContext
        {
            get { return Context as CoffeeShopContext; }
        }
    }
}