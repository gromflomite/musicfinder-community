using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFCommunity.Models
{
    public class User : IdentityUser
    {
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? UserImage { get; set; }
    }
}
