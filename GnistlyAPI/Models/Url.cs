using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_Url")]
    public class Url
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UrlID { get; set; }
        public DateTime UrlDate { get; set; }
        public string UrlString { get; set; }

        public int CustomerID { get; set; } //FK
        public Customer Customer { get; set; } //Navigation Property
    }
}