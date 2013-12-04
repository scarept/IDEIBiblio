namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cat_livro_cat_revista : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cat_Livro",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cat_Revista",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Livro", "categoria_ID", c => c.Int());
            AddColumn("dbo.Revista", "categoria_ID", c => c.Int());
            AddForeignKey("dbo.Livro", "categoria_ID", "dbo.Cat_Livro", "ID");
            AddForeignKey("dbo.Revista", "categoria_ID", "dbo.Cat_Revista", "ID");
            CreateIndex("dbo.Livro", "categoria_ID");
            CreateIndex("dbo.Revista", "categoria_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Revista", new[] { "categoria_ID" });
            DropIndex("dbo.Livro", new[] { "categoria_ID" });
            DropForeignKey("dbo.Revista", "categoria_ID", "dbo.Cat_Revista");
            DropForeignKey("dbo.Livro", "categoria_ID", "dbo.Cat_Livro");
            DropColumn("dbo.Revista", "categoria_ID");
            DropColumn("dbo.Livro", "categoria_ID");
            DropTable("dbo.Cat_Revista");
            DropTable("dbo.Cat_Livro");
        }
    }
}
