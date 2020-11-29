using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_Edit")]
    public class Edit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int EditID { get; set; }
        public DateTime EditDate { get; set; }

        public int IdeaID { get; set; } //FK
        public Idea Idea { get; set; } //Navigation Property

        public int UserID { get; set; } //FK
        public User User { get; set; } //Navigation Property
    }

}