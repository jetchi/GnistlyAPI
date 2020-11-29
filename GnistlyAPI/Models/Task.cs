using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_Task")]
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int TaskID { get; set; }
        
        public int IdeaID { get; set; } //FK
        public Idea Idea { get; set; } //Navigation Property
    }
}