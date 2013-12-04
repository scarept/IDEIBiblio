namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEncomenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Encomenda",
                c => new
                    {
                        EncomendaID = c.Int(nullable: false, identity: true),
                        data = c.DateTime(nullable: false),
                        compra_ID = c.Int(),
                        cliente_ID = c.Int(),
                    })
                .PrimaryKey(t => t.EncomendaID)
                .ForeignKey("dbo.Compra", t => t.compra_ID)
                .ForeignKey("dbo.Cliente", t => t.cliente_ID)
                .Index(t => t.compra_ID)
                .Index(t => t.cliente_ID);
            
            AddColumn("dbo.Linha_Doc", "Encomenda_EncomendaID", c => c.Int());
            AddForeignKey("dbo.Linha_Doc", "Encomenda_EncomendaID", "dbo.Encomenda", "EncomendaID");
            CreateIndex("dbo.Linha_Doc", "Encomenda_EncomendaID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Encomenda", new[] { "cliente_ID" });
            DropIndex("dbo.Encomenda", new[] { "compra_ID" });
            DropIndex("dbo.Linha_Doc", new[] { "Encomenda_EncomendaID" });
            DropForeignKey("dbo.Encomenda", "cliente_ID", "dbo.Cliente");
            DropForeignKey("dbo.Encomenda", "compra_ID", "dbo.Compra");
            DropForeignKey("dbo.Linha_Doc", "Encomenda_EncomendaID", "dbo.Encomenda");
            DropColumn("dbo.Linha_Doc", "Encomenda_EncomendaID");
            DropTable("dbo.Encomenda");
        }
    }
}
