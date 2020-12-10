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

            //context.Departments.AddOrUpdate(new Models.Department { DepartmentName = "Tekniker" });

            //context.Users.AddOrUpdate(new Models.User { UserFname = "Lars", UserLname = "Larsen", CustomerID = 1 });

            //context.ZipCodes.AddOrUpdate(new Models.ZipCode {
            //    Zip = "8000",
            //    ZipCodeCity = "ArhusC"
            //});

            context.Departments.AddOrUpdate(
                new Models.Department { DepartmentName = "Manager" },
                new Models.Department { DepartmentName = "Ingeniør" });

            context.ZipCodes.AddOrUpdate(
                new Models.ZipCode { Zip = "7000", ZipCodeCity = "Fredericia" },
                new Models.ZipCode { Zip = "6000", ZipCodeCity = "Kolding" },
                new Models.ZipCode { Zip = "5000", ZipCodeCity = "Odense C" },
                new Models.ZipCode { Zip = "4000", ZipCodeCity = "Roskilde" },
                new Models.ZipCode { Zip = "3000", ZipCodeCity = "Helsingør" },
                new Models.ZipCode { Zip = "2000", ZipCodeCity = "Frederiksberg" },
                new Models.ZipCode { Zip = "1000", ZipCodeCity = "København K" },
                new Models.ZipCode { Zip = "6430", ZipCodeCity = "Nordborg" },
                new Models.ZipCode { Zip = "6320", ZipCodeCity = "Egernsund" });

            context.Users.AddOrUpdate(
                new Models.User { UserFname = "Hans", UserLname = "Hansen", DepartmentID = 3, CustomerID = 1 }, 
                new Models.User { UserFname = "Louise", UserLname = "Louisen", DepartmentID = 3, CustomerID = 1 },
                new Models.User { UserFname = "Andrea", UserLname = "Andreasen", DepartmentID = 3, CustomerID = 2 },
                new Models.User { UserFname = "Johanna", UserLname = "Johansen", DepartmentID = 3, CustomerID = 2 });

        }
    }
}
