namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDB : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.salaryId)
                .ForeignKey("dbo.Empployes", t => t.EmployeId, cascadeDelete: true)
                .Index(t => t.EmployeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "EmployeId", "dbo.Empployes");
            DropIndex("dbo.Salaries", new[] { "EmployeId" });
            DropTable("dbo.Salaries");
        }
    }
}
