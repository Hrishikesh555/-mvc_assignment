namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empployes", "EmployeName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empployes", "EmployeName", c => c.String(nullable: false));
        }
    }
}
