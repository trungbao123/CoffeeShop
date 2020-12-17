using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string UserNv { get; set; }
        public DateTime NgayLap { get; set; }

        [DataType(DataType.Currency)]
        public decimal TongTien { get; set; }
    }
}