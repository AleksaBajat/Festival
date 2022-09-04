using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.Enums.CommonEnumerations;

namespace Context.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string Name { get; set; }
        
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public User() {}
    }
}