using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GnistlyAPI.Models
{
    public class Context : DbContext
    {
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public Context() : base("name=Context")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.ZipCode> ZipCodes { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.Edit> Edits { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.File> Files { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.Hashtag> Hashtags { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.Idea> Ideas { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.Task> Tasks { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.Url> Urls { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<GnistlyAPI.Models.Password> Passwords { get; set; }
    }
}