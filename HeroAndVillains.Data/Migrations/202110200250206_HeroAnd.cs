namespace HeroAndVillains.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HeroAnd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Team", "Name");
        }
    }
}
