namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LatestUpd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Salaries", "EmployeId", "dbo.Empployes");
            DropIndex("dbo.Salaries", new[] { "EmployeId" });
            DropColumn("dbo.Empployes", "Salary");
            DropTable("dbo.Salaries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        salaryId = c.Int(nullable: false, identity: true),
                        EmployeId = c.Int(nullable: false),
                        salary = c.Int(nullable: false),
                        tax = c.Int(nullable: false),
                        nSal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.salaryId);
            
            AddColumn("dbo.Empployes", "Salary", c => c.Int(nullable: false));
            CreateIndex("dbo.Salaries", "EmployeId");
            AddForeignKey("dbo.Salaries", "EmployeId", "dbo.Empployes", "EmployeId", cascadeDelete: true);
        }
    }
}
