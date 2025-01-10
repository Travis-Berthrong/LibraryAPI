using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Data
{
    public class User : IdentityUser
    {
        [Required, MaxLength(100)]
        public string? FirstName { get; set; }
        [Required, MaxLength(100)]
        public string? LastName { get; set; }

    }
}
