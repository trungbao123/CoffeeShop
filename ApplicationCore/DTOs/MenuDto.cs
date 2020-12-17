using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}