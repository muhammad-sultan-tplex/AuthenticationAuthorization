using System.ComponentModel.DataAnnotations;
using AuthenticationAuthorization.Generics;

namespace AuthenticationAuthorization.Models
{
    public class UserModel: BaseEntity
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public RoleModel Role { get; set; }
    }
}
