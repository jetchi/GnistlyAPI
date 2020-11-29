using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_Status")]
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int StatusID { get; set; }
        public string StatusDescription { get; set; }

        public int IdeaID { get; set; } //FK
        public Idea Idea { get; set; } //Navigation Property
    }
}