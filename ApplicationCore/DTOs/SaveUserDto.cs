using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs
{
    public class SaveUserDto
    {
        public int UserId { get; set; }

        [RegularExpression(@"^[A-Z]+[A-Za-z""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Username { get; set; }
        [RegularExpression(@"^[A-Z]+[A-Za-z""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Password { get; set; }
        [RegularExpression(@"^[A-Z]+[A-Za-z""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Role { get; set; }
        public int Status { get; set; }
    }
}