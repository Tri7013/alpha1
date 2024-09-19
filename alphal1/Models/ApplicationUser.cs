using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace alphal1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string LoginName { get; set; }
    }

}
