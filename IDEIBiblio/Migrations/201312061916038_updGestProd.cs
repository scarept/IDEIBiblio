namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updGestProd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gestor_P", "profile", c => c.Int(nullable: false));
            DropColumn("dbo.Gestor_P", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gestor_P", "Password", c => c.String());
            DropColumn("dbo.Gestor_P", "profile");
        }
    }
}
