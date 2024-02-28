using System.ComponentModel.DataAnnotations;
using AuthenticationAuthorization.Generics;

namespace AuthenticationAuthorization.Models
{
    public class RoleModel: BaseEntity
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
