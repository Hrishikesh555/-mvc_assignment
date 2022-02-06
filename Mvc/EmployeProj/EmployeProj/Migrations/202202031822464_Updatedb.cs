namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Empployes", "DateOfLeaving");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empployes", "DateOfLeaving", c => c.DateTime());
        }
    }
}
