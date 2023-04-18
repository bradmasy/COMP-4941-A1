namespace assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _146 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "JobID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "JobID", c => c.Int(nullable: false));
        }
    }
}
