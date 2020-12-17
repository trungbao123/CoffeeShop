using System;

namespace ApplicationCore.DTOs
{
    public class MaterialDto
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string Status { get; set; }
        public DateTime ReceiptDate { get; set; }
        
    }
}