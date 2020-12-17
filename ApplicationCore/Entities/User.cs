using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class User : IAggregateRoot
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Status { get; set; }
    }
}