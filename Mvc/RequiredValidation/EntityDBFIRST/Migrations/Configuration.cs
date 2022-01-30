namespace EntityDBFIRST.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityDBFIRST.Models.CompanyDbCotext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityDBFIRST.Models.CompanyDbCotext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1,BrandName="Samsung" });
            context.Categories.AddOrUpdate(new Models.Category() { CategoryID = 1,CategoryName="Home Appliance" });
        }
    }
}
