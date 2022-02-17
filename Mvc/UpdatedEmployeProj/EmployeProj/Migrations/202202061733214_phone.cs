namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empployes", "Contact", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empployes", "Contact", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
