namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUnitPriceLinhaDoc_andname : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Linha_Fat", "produto_ID", "dbo.Produto");
            DropForeignKey("dbo.Linha_Fat", "Fatura_ID", "dbo.Fatura");
            DropIndex("dbo.Linha_Fat", new[] { "produto_ID" });
            DropIndex("dbo.Linha_Fat", new[] { "Fatura_ID" });
            CreateTable(
                "dbo.Linha_Doc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        qtd = c.Single(nullable: false),
                        preço_unitário = c.Single(nullable: false),
                        produto_ID = c.Int(),
                        Fatura_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Produto", t => t.produto_ID)
                .ForeignKey("dbo.Fatura", t => t.Fatura_ID)
                .Index(t => t.produto_ID)
                .Index(t => t.Fatura_ID);
            
            DropTable("dbo.Linha_Fat");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Linha_Fat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        qtd = c.Single(nullable: false),
                        produto_ID = c.Int(),
                        Fatura_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropIndex("dbo.Linha_Doc", new[] { "Fatura_ID" });
            DropIndex("dbo.Linha_Doc", new[] { "produto_ID" });
            DropForeignKey("dbo.Linha_Doc", "Fatura_ID", "dbo.Fatura");
            DropForeignKey("dbo.Linha_Doc", "produto_ID", "dbo.Produto");
            DropTable("dbo.Linha_Doc");
            CreateIndex("dbo.Linha_Fat", "Fatura_ID");
            CreateIndex("dbo.Linha_Fat", "produto_ID");
            AddForeignKey("dbo.Linha_Fat", "Fatura_ID", "dbo.Fatura", "ID");
            AddForeignKey("dbo.Linha_Fat", "produto_ID", "dbo.Produto", "ID");
        }
    }
}
