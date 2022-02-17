namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empployes", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Empployes", new[] { "DepartmentId" });
            AddColumn("dbo.Empployes", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Empployes", "EmployeName", c => c.String(nullable: false));
            AlterColumn("dbo.Empployes", "Designation", c => c.String(nullable: false));
            AlterColumn("dbo.Empployes", "DateOfJoing", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Empployes", "Contact", c => c.String(nullable: false));
            AlterColumn("dbo.Empployes", "DepartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Empployes", "Status", c => c.String(nullable: false));
            CreateIndex("dbo.Empployes", "DepartmentId");
            AddForeignKey("dbo.Empployes", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            DropColumn("dbo.Empployes", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empployes", "Adress", c => c.String());
            DropForeignKey("dbo.Empployes", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Empployes", new[] { "DepartmentId" });
            AlterColumn("dbo.Empployes", "Status", c => c.String());
            AlterColumn("dbo.Empployes", "DepartmentId", c => c.Int());
            AlterColumn("dbo.Empployes", "Contact", c => c.String());
            AlterColumn("dbo.Empployes", "DateOfJoing", c => c.DateTime());
            AlterColumn("dbo.Empployes", "Designation", c => c.String());
            AlterColumn("dbo.Empployes", "EmployeName", c => c.String());
            DropColumn("dbo.Empployes", "City");
            CreateIndex("dbo.Empployes", "DepartmentId");
            AddForeignKey("dbo.Empployes", "DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
