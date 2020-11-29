using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_ZipCode")]
    public class ZipCode
    {
        [Key]
        [Required]
        public string Zip { get; set; }
        public string ZipCodeCity { get; set; }
    }
}