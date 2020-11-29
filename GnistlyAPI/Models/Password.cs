using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_Password")]
    public class Password
    {
        [Key]
        [Required]
        [StringLength(6)]
        public string PasswordChars { get; set; }

        public int UserID { get; set; } //FK
        public User User { get; set; } //Navigation Property
    }
}