using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int PoatalCode { get; set; }

        public int? CompanyId { get; set; } // (?) <- this symbol represent item can be a nullable field
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
