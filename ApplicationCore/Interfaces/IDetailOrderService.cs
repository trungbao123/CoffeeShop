using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IDetailOrderService
    {
        DetailOrderDto GetDetailOrder(int orderId);
        IEnumerable<DetailOrderDto> GetDetailOrders(string MenuName);
        IEnumerable<string> GetMenuNames();
        void CreateDetailOrder(SaveDetailOrderDto DetailOrderDto);
        void UpdateDetailOrder(SaveDetailOrderDto DetailOrderDto);
        void DeleteDetailOrder(int DetailOrderId);
    }
}