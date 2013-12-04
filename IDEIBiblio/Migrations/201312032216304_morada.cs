namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morada : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moradas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        rua = c.String(),
                        porta = c.Int(nullable: false),
                        andar = c.String(),
                        cod_postal = c.String(),
                        país = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Clientes", "morada_ID", c => c.Int());
            AddForeignKey("dbo.Clientes", "morada_ID", "dbo.Moradas", "ID");
            CreateIndex("dbo.Clientes", "morada_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", new[] { "morada_ID" });
            DropForeignKey("dbo.Clientes", "morada_ID", "dbo.Moradas");
            DropColumn("dbo.Clientes", "morada_ID");
            DropTable("dbo.Moradas");
        }
    }
}
