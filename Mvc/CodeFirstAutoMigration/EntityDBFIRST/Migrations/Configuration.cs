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
            AutomaticMigrationsEnabled = true;
            ContextKey = "EntityDBFIRST.Models.CompanyDbCotext";
        }

        protected override void Seed(EntityDBFIRST.Models.CompanyDbCotext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1, BrandName = "Apple" },new Models.Brand(){BrandID=2 ,BrandName="Samsung"});
            context.Categories.AddOrUpdate(new Models.Category() { CategoryID=1,CategoryName="Mobile" }, new Models.Category() { CategoryID=2,CategoryName="Home Application"});
        }
    }
}
