namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LatestUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        SalID = c.Int(nullable: false, identity: true),
                        Salarys = c.Int(nullable: false),
                        Tax = c.Int(nullable: false),
                        HRA = c.Int(nullable: false),
                        DA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalID);
            
            AddColumn("dbo.Empployes", "SalId", c => c.Int());
            CreateIndex("dbo.Empployes", "SalId");
            AddForeignKey("dbo.Empployes", "SalId", "dbo.Salaries", "SalID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empployes", "SalId", "dbo.Salaries");
            DropIndex("dbo.Empployes", new[] { "SalId" });
            DropColumn("dbo.Empployes", "SalId");
            DropTable("dbo.Salaries");
        }
    }
}
