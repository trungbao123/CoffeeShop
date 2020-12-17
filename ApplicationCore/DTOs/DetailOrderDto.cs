using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs
{
    public class DetailOrderDto
    {
        public int DetailOrderId { get; set; }
        public OrderDto OrderDto { get; set; }
        public int OrderId { get; set; }
        public MenuDto MenuDto { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }
}