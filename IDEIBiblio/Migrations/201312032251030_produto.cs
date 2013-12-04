namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class produto : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Clientes", newName: "Cliente");
            RenameTable(name: "dbo.Moradas", newName: "Morada");
            RenameTable(name: "dbo.Compras", newName: "Compra");
            RenameTable(name: "dbo.Faturas", newName: "Fatura");
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                        editora = c.String(),
                        preco = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        isbn = c.Int(nullable: false),
                        publicação = c.Int(nullable: false),
                        sinopse = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Produto", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Revista",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        numero = c.Int(nullable: false),
                        edição = c.DateTime(nullable: false),
                        país = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Produto", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Revista", new[] { "ID" });
            DropIndex("dbo.Livro", new[] { "ID" });
            DropForeignKey("dbo.Revista", "ID", "dbo.Produto");
            DropForeignKey("dbo.Livro", "ID", "dbo.Produto");
            DropTable("dbo.Revista");
            DropTable("dbo.Livro");
            DropTable("dbo.Produto");
            RenameTable(name: "dbo.Fatura", newName: "Faturas");
            RenameTable(name: "dbo.Compra", newName: "Compras");
            RenameTable(name: "dbo.Morada", newName: "Moradas");
            RenameTable(name: "dbo.Cliente", newName: "Clientes");
        }
    }
}
