namespace assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Name", c => c.String());
            AddColumn("dbo.Customer", "Department", c => c.String());
            AddColumn("dbo.Employee", "Address", c => c.String());
            DropColumn("dbo.Customer", "PropertyA");
            DropColumn("dbo.Employee", "PropertyB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "PropertyB", c => c.String());
            AddColumn("dbo.Customer", "PropertyA", c => c.String());
            DropColumn("dbo.Employee", "Address");
            DropColumn("dbo.Customer", "Department");
            DropColumn("dbo.People", "Name");
        }
    }
}
