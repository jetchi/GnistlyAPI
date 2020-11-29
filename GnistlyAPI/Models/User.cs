using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    [Table("tbl_User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserID { get; set; }
        public string UserFname { get; set; }
        public string UserLname { get; set; }
        
        public int DepartmentID { get; set; } //FK
        public Department Department { get; set; } //Navigation Property

        public int CustomerID { get; set; } // FK
        public Customer Customer { get; set; } //Navigation Property

    }
}