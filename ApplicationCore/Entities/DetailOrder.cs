using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class DetailOrder : IAggregateRoot
    {
        public int DetailOrderId { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}