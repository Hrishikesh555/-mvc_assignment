namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LatestUpdat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empployes", "Sals", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empployes", "Sals");
        }
    }
}
