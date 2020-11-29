using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_Deparment")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}