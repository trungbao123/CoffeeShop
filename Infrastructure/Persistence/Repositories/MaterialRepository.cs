using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(CoffeeShopContext context) : base(context)
        {
        }

        public IEnumerable<string> GetStatuses()
        {
            var statuses = from m in CoffeeShopContext.Materials
                         orderby m.Status
                         select m.Status;

            return statuses.Distinct().ToList();
        }

        protected CoffeeShopContext CoffeeShopContext
        {
            get { return Context as CoffeeShopContext; }
        }
    }
}