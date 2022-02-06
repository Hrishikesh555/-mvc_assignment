namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        DepartmentLoc = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Empployes",
                c => new
                    {
                        EmployeId = c.Int(nullable: false, identity: true),
                        EmployeName = c.String(),
                        Designation = c.String(),
                        Profile = c.String(),
                        DateOfJoing = c.DateTime(),
                        DateOfLeaving = c.DateTime(),
                        Adress = c.String(),
                        Contact = c.String(),
                        DepartmentId = c.Int(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.EmployeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empployes", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Empployes", new[] { "DepartmentId" });
            DropTable("dbo.Empployes");
            DropTable("dbo.Departments");
        }
    }
}
