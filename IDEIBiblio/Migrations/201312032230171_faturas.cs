namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faturas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faturas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        numero = c.Int(nullable: false),
                        data = c.DateTime(nullable: false),
                        vencimento = c.DateTime(nullable: false),
                        portes = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Compras", "fatura_ID", c => c.Int());
            AddForeignKey("dbo.Compras", "fatura_ID", "dbo.Faturas", "ID");
            CreateIndex("dbo.Compras", "fatura_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Compras", new[] { "fatura_ID" });
            DropForeignKey("dbo.Compras", "fatura_ID", "dbo.Faturas");
            DropColumn("dbo.Compras", "fatura_ID");
            DropTable("dbo.Faturas");
        }
    }
}
