namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empployes", "EmployeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empployes", "EmployeName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
