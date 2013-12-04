namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCarrinho : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrinho",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Item_Carrinho",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        qtd = c.Int(nullable: false),
                        produto_ID = c.Int(),
                        Carrinho_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Produto", t => t.produto_ID)
                .ForeignKey("dbo.Carrinho", t => t.Carrinho_ID)
                .Index(t => t.produto_ID)
                .Index(t => t.Carrinho_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Item_Carrinho", new[] { "Carrinho_ID" });
            DropIndex("dbo.Item_Carrinho", new[] { "produto_ID" });
            DropForeignKey("dbo.Item_Carrinho", "Carrinho_ID", "dbo.Carrinho");
            DropForeignKey("dbo.Item_Carrinho", "produto_ID", "dbo.Produto");
            DropTable("dbo.Item_Carrinho");
            DropTable("dbo.Carrinho");
        }
    }
}
