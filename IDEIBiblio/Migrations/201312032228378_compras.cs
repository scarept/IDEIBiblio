namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        data = c.DateTime(nullable: false),
                        total = c.Single(nullable: false),
                        cliente_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.cliente_ID)
                .Index(t => t.cliente_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Compras", new[] { "cliente_ID" });
            DropForeignKey("dbo.Compras", "cliente_ID", "dbo.Clientes");
            DropTable("dbo.Compras");
        }
    }
}
