namespace assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _141 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Customer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "Employee_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Employee_Id");
            DropColumn("dbo.Customer", "Customer_Id");
        }
    }
}
