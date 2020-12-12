using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_Idea")]
    public class Idea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // required deleted, tested and must stay deleted
        public int IdeaID { get; set; }
        public string IdeaTitle { get; set; }
        public string IdeaDescription { get; set; }
        public DateTime IdeaDate { get; set; }
        public int IdeaImpact { get; set; }
        public int IdeaEffort { get; set; }

        public int IdeaSavings { get; set; }
        public string IdeaChallenges { get; set; }
        public string IdeaResults { get; set; }

        public int UserID { get; set; } // FK

        [ForeignKey("UserID")]
        public User User { get; set; } //Navigation Property
    }
}