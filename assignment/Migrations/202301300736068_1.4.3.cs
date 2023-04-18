namespace assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _143 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Address", c => c.String());
            AddColumn("dbo.Employee", "Department", c => c.String());
            DropColumn("dbo.Customer", "Department");
            DropColumn("dbo.Employee", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Address", c => c.String());
            AddColumn("dbo.Customer", "Department", c => c.String());
            DropColumn("dbo.Employee", "Department");
            DropColumn("dbo.Customer", "Address");
        }
    }
}
