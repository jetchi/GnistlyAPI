using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_Comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        
        public int IdeaID { get; set; } //FK
        public Idea Idea { get; set; } //Navigation Property // make virtual to achieve lazy loading
    }
}