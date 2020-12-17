using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs
{
    public class SaveMaterialDto
    {
        public int MaterialId { get; set; }

        [RegularExpression(@"^[A-Z]+[A-Za-z""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string MaterialName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Unit { get; set; }

        [RegularExpression(@"^[A-Z]+[A-Za-z""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        public string Status { get; set; }

        [Display(Name = "Receipt Date")]
        [DataType(DataType.Date)]
        public DateTime ReceiptDate { get; set; }
    }
}