using System;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Material : IAggregateRoot
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string Status { get; set; }
        public DateTime ReceiptDate { get; set; }
        
    }
}