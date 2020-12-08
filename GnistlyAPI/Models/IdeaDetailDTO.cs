using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    public class IdeaDetailDTO
    {
        public int IdeaID { get; set; }
        public string IdeaTitle { get; set; }
        public string IdeaDescription { get; set; }
        public DateTime IdeaDate { get; set; }
        public int IdeaImpact { get; set; }
        public int IdeaEffort { get; set; }
        public int IdeaSavings { get; set; }
        public string IdeaChallenges { get; set; }
        public string IdeaResults { get; set; }
        public string IdeaAuthor { get; set; }





    }
}