namespace EntityDBFIRST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
