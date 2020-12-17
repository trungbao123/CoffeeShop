using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.DTOs
{
    public class SaveOrderDto
    {
        public int OrderId { get; set; }
        public string UserNv { get; set; }

        [DataType(DataType.Date)]
        public DateTime NgayLap { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTien { get; set; }
    }
}