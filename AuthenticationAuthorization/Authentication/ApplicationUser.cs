using AuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationAuthorization.Authentication
{
    public class ApplicationUser: IdentityUser
    {
        public IdentityRole Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
