using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWater.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(5, ErrorMessage ="Username must be at least 5 characters long")]
        [MaxLength(15, ErrorMessage ="Username cannot exceed 15 characters")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}