namespace GnistlyAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GnistlyAPI.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GnistlyAPI.Models.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //context.ZipCodes.AddOrUpdate(new Models.ZipCode { Zip = "8000", ZipCodeCity = "Aarhus" },
            //    new Models.ZipCode { Zip = "6300", ZipCodeCity = "Sonderborg" });

            //context.Customers.AddOrUpdate(new Models.Customer { CustomerName = "LINAK", CustomerStreet = "Gade", CustomerMail = "linak@web.dk", CustomerPhone = "45691237", Zip = "6300", CustomerStatus = true },
            //    new Models.Customer { CustomerName = "DANFOSS", CustomerStreet = "Straede", CustomerMail = "danfoss@web.dk", CustomerPhone = "74951682", Zip = "6300", CustomerStatus = true });

            context.Departments.AddOrUpdate(new Models.Department { DepartmentName = "Techniker" });

            context.Users.AddOrUpdate(new Models.User { UserFname = "Lars", UserLname = "Larsen", CustomerID = 1 });
        }
    }
}
