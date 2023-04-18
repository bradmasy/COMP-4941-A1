namespace assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _144 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ServiceId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceId, t.CustomerId })
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Services", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Jobs", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Services", new[] { "EmployeeID" });
            DropIndex("dbo.Jobs", new[] { "CustomerId" });
            DropIndex("dbo.Jobs", new[] { "ServiceId" });
            DropTable("dbo.Services");
            DropTable("dbo.Jobs");
        }
    }
}
