using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnumTest.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Gender UserGender { get; set; }
        public int? GenderId { get; set; }
    }
}