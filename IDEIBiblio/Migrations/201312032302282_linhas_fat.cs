namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linhas_fat : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Produto", t => t.produto_ID)
                .ForeignKey("dbo.Fatura", t => t.Fatura_ID)
                .Index(t => t.produto_ID)
                .Index(t => t.Fatura_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Linha_Fat", new[] { "Fatura_ID" });
            DropIndex("dbo.Linha_Fat", new[] { "produto_ID" });
            DropForeignKey("dbo.Linha_Fat", "Fatura_ID", "dbo.Fatura");
            DropForeignKey("dbo.Linha_Fat", "produto_ID", "dbo.Produto");
            DropTable("dbo.Linha_Fat");
        }
    }
}
