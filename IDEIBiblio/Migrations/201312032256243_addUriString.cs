namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUriString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livro", "path_img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livro", "path_img");
        }
    }
}
