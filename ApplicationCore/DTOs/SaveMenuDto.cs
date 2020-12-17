using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.DTOs
{
    public class SaveMenuDto
    {
        public int MenuId {get; set;}

        [RegularExpression(@"^[A-Z]+[A-Za-z""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name {get; set;}

        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[A-Za-z""'\s-]*$")]
        [Required]
        public string Genre {get; set;}

        [Range(1, 100)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price {get;set;}

        [RegularExpression(@"^[A-Z]+[A-Za-z""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        public string Status {get;set;}
    }
}