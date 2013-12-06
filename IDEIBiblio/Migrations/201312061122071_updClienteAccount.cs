namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updClienteAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "profile", c => c.Int(nullable: false));
            DropColumn("dbo.Cliente", "user_profile_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cliente", "user_profile_id", c => c.Int(nullable: false));
            DropColumn("dbo.Cliente", "profile");
        }
    }
}
