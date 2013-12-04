namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipo_publicação : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tipo_Pub",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Revista", "tipo_publicação_ID", c => c.Int());
            AddForeignKey("dbo.Revista", "tipo_publicação_ID", "dbo.Tipo_Pub", "ID");
            CreateIndex("dbo.Revista", "tipo_publicação_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Revista", new[] { "tipo_publicação_ID" });
            DropForeignKey("dbo.Revista", "tipo_publicação_ID", "dbo.Tipo_Pub");
            DropColumn("dbo.Revista", "tipo_publicação_ID");
            DropTable("dbo.Tipo_Pub");
        }
    }
}
