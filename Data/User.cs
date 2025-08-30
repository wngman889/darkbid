﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarkBid.Data
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("username")]
        public string? Username { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("email")]
        public string? Email { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("password")]
        public string? Password { get; set; }

        //[Required]
        //[Column("created_at")]
        //public DateTime CreatedAt { get; set; }

        //[Required]
        //[Column("updated_at")]
        //public DateTime UpdatedAt { get; set; }
    }
}
