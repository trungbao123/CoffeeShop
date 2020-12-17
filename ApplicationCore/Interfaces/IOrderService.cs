using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        OrderDto GetOrder(int orderId);
        IEnumerable<OrderDto> GetOrders(string userName);
        IEnumerable<string> GetUsers();
        int getIDod();
        void CreateOrder(SaveOrderDto OrderDto);
        void UpdateOrder(SaveOrderDto OrderDto);
        void DeleteOrder(int orderId);
    }
}