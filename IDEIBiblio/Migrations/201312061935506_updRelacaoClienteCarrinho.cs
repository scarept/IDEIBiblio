namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updRelacaoClienteCarrinho : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "carrinho_ID", c => c.Int());
            AddForeignKey("dbo.Cliente", "carrinho_ID", "dbo.Carrinho", "ID");
            CreateIndex("dbo.Cliente", "carrinho_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cliente", new[] { "carrinho_ID" });
            DropForeignKey("dbo.Cliente", "carrinho_ID", "dbo.Carrinho");
            DropColumn("dbo.Cliente", "carrinho_ID");
        }
    }
}
