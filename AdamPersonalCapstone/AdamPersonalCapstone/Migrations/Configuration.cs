namespace AdamPersonalCapstone.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AdamPersonalCapstone.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AdamPersonalCapstone.Models.ApplicationDbContext context)
        {
            //context.Devices.AddOrUpdate(
            //    new Models.Device { DevicesId = 2, Brand = "Apple", Name = "iPhone 11 Pro Max" },
            //    new Models.Device { DevicesId = 3, Brand = "Apple", Name = "iPhone 11 Pro" },
            //    new Models.Device { DevicesId = 4, Brand = "Apple", Name = "iPhone 11" },
            //    new Models.Device { DevicesId = 5, Brand = "Apple", Name = "iPhone XS Max" },
            //    new Models.Device { DevicesId = 6, Brand = "Apple", Name = "iPhone XS" },
            //    new Models.Device { DevicesId = 7, Brand = "Apple", Name = "iPhone XR" },
            //    new Models.Device { DevicesId = 8, Brand = "Apple", Name = "iPhone X" },
            //    new Models.Device { DevicesId = 9, Brand = "Apple", Name = "iPhone 8+" },
            //    new Models.Device { DevicesId = 10, Brand = "Apple", Name = "iPhone 8" },
            //    new Models.Device { DevicesId = 11, Brand = "Apple", Name = "iPhone 7+" },
            //    new Models.Device { DevicesId = 12, Brand = "Apple", Name = "iPhone 7" },
            //    new Models.Device { DevicesId = 13, Brand = "Apple", Name = "iPhone SE" },
            //    new Models.Device { DevicesId = 14, Brand = "Apple", Name = "iPhone 6s+" },
            //    new Models.Device { DevicesId = 15, Brand = "Apple", Name = "iPhone 6s" },
            //    new Models.Device { DevicesId = 16, Brand = "Apple", Name = "iPhone 6+" },
            //    new Models.Device { DevicesId = 17, Brand = "Apple", Name = "iPhone 6" },
            //    new Models.Device { DevicesId = 18, Brand = "Apple", Name = "iPhone 5s" },
            //    new Models.Device { DevicesId = 19, Brand = "Apple", Name = "iPhone 5c" },
            //    new Models.Device { DevicesId = 20, Brand = "Apple", Name = "iPhone 4s" },
            //    new Models.Device { DevicesId = 21, Brand = "Apple", Name = "iPhone 4" },
            //    new Models.Device { DevicesId = 22, Brand = "Apple", Name = "iPhone 3Gs" },
            //    new Models.Device { DevicesId = 23, Brand = "Apple", Name = "iPhone 3" },
            //    new Models.Device { DevicesId = 24, Brand = "Apple", Name = "Other" },
            //    new Models.Device { DevicesId = 25, Brand = "Samsung", Name = "Note 10+ 5G" },
            //    new Models.Device { DevicesId = 26, Brand = "Samsung", Name = "Note 10+" },
            //    new Models.Device { DevicesId = 27, Brand = "Samsung", Name = "Note 10" },
            //    new Models.Device { DevicesId = 28, Brand = "Samsung", Name = "Galaxy S10+" },
            //    new Models.Device { DevicesId = 29, Brand = "Samsung", Name = "Galaxy S10" },
            //    new Models.Device { DevicesId = 30, Brand = "Samsung", Name = "Galaxy S10e" },
            //    new Models.Device { DevicesId = 31, Brand = "Samsung", Name = "Note 9" },
            //    new Models.Device { DevicesId = 32, Brand = "Samsung", Name = "Galaxy S9+" },
            //    new Models.Device { DevicesId = 33, Brand = "Samsung", Name = "Galaxy S9" },
            //    new Models.Device { DevicesId = 34, Brand = "Samsung", Name = "Note 8" },
            //    new Models.Device { DevicesId = 35, Brand = "Samsung", Name = "Galaxy S8+" },
            //    new Models.Device { DevicesId = 36, Brand = "Samsung", Name = "Galaxy S8" },
            //    new Models.Device { DevicesId = 37, Brand = "Samsung", Name = "Galaxy S8 Active" },
            //    new Models.Device { DevicesId = 38, Brand = "Samsung", Name = "Galaxy S7" },
            //    new Models.Device { DevicesId = 39, Brand = "Samsung", Name = "Galaxy S7 Edge" },
            //    new Models.Device { DevicesId = 40, Brand = "Samsung", Name = "Galaxy S7 Active" },
            //    new Models.Device { DevicesId = 41, Brand = "Samsung", Name = "Galaxy S6" },
            //    new Models.Device { DevicesId = 42, Brand = "Samsung", Name = "Galaxy S6 Edge" },
            //    new Models.Device { DevicesId = 43, Brand = "Samsung", Name = "Galaxy S6 Edge+" },
            //    new Models.Device { DevicesId = 44, Brand = "Samsung", Name = "Note 5" },
            //    new Models.Device { DevicesId = 45, Brand = "Samsung", Name = "Galaxy S5" },
            //    new Models.Device { DevicesId = 46, Brand = "Samsung", Name = "Galaxy S5+" },
            //    new Models.Device { DevicesId = 47, Brand = "Samsung", Name = "Galaxy S5 Active" },
            //    new Models.Device { DevicesId = 48, Brand = "Samsung", Name = "Galaxy S5 Mini" },
            //    new Models.Device { DevicesId = 49, Brand = "Samsung", Name = "Galaxy A10e" },
            //    new Models.Device { DevicesId = 50, Brand = "Samsung", Name = "Galaxy A20" },
            //    new Models.Device { DevicesId = 51, Brand = "Samsung", Name = "Galaxy J3" },
            //    new Models.Device { DevicesId = 52, Brand = "Samsung", Name = "Galaxy J7" },
            //    new Models.Device { DevicesId = 53, Brand = "Samsung", Name = "Other" }
            //    );



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
