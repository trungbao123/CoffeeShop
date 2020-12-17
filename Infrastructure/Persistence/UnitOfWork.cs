using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoffeeShopContext _context;
        public UnitOfWork(CoffeeShopContext context)
        {
            Menus = new MenuRepository(context);
            Users = new UserRepository(context);
            Orders = new OrderRepository(context);
            Materials = new MaterialRepository(context);
            DetailOrders = new DetailOrderRepository(context);
            _context = context;
        }

        public IMenuRepository Menus { get; private set; }
        public IUserRepository Users { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IDetailOrderRepository DetailOrders { get; private set; }
        public IMaterialRepository Materials { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}