﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    // code first approach

    [Table("tbl_Customers")]
    public class Customer
    {
        [Key]
        [Required] // will throw "System.Data.Entity.Validation.DbEntityValidationException" exception if we try to store withaout a value in this field
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; } // Guid = "global unique identifier" did not work just like this

        [Required]
        public string CustomerName { get; set; }
        public string CustomerMail { get; set; }
        public bool CustomerStatus { get; set; }

        public string CustomerPhone { get; set; }
        public string CustomerStreet { get; set; }

        // [ForeignKey("Zip")] As per the default convention, EF makes a property as foreign key property when it's name matches with the primary key property of a related entity.
        [StringLength(4)]
        public string Zip { get; set; }

        [ForeignKey("Zip")]
        public ZipCode ZipCode { get; set; } //Navigation Property 
        //The customer class contains the navigation property to the related ZipCode table.
    }
}