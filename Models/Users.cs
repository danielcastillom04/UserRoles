using Microsoft.AspNetCore.Identity;

namespace UserRoles.Models
{
    public class Users : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
