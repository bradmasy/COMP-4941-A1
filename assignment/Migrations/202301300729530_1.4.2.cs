namespace assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _142 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "Customer_Id");
            DropColumn("dbo.Employee", "Employee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Employee_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "Customer_Id", c => c.Int(nullable: false));
        }
    }
}
