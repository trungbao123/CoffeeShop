using System;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Order : IAggregateRoot
    {
        public int OrderId { get; set; }
        public string UserNv { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
    }
}