using System.Linq;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class DetailOrderRepository : Repository<DetailOrder>, IDetailOrderRepository
    {
        public DetailOrderRepository(CoffeeShopContext context) : base(context)
        {
        }

        public IEnumerable<string> GetMenuNames()
        {
            var MenuName = from m in CoffeeShopContext.DetailOrders
                           orderby m.MenuName
                           select m.MenuName;

            return MenuName.Distinct().ToList();
        }

        protected CoffeeShopContext CoffeeShopContext
        {
            get { return Context as CoffeeShopContext; }
        }
    }
}