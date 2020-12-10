using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_Hashtag")]
    public class Hashtag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        public int HashtagID { get; set; }
        public string HashtagText { get; set; }
        
        public int IdeaID { get; set; } //FK
        public Idea Idea { get; set; } //Navigation Property
    }
}