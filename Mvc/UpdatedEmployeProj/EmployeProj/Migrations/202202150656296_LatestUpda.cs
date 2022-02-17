namespace EmployeProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LatestUpda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empployes", "SalId", "dbo.Salaries");
            DropIndex("dbo.Empployes", new[] { "SalId" });
            AddColumn("dbo.Salaries", "EmployeId", c => c.Int());
            CreateIndex("dbo.Salaries", "EmployeId");
            AddForeignKey("dbo.Salaries", "EmployeId", "dbo.Empployes", "EmployeId");
            DropColumn("dbo.Empployes", "SalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empployes", "SalId", c => c.Int());
            DropForeignKey("dbo.Salaries", "EmployeId", "dbo.Empployes");
            DropIndex("dbo.Salaries", new[] { "EmployeId" });
            DropColumn("dbo.Salaries", "EmployeId");
            CreateIndex("dbo.Empployes", "SalId");
            AddForeignKey("dbo.Empployes", "SalId", "dbo.Salaries", "SalID");
        }
    }
}
