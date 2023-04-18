namespace assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _145 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "JobID");
        }
    }
}
