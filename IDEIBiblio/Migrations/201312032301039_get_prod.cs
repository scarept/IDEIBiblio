namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class get_prod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gestor_P",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Produto", "gestor_produto_ID", c => c.Int());
            AddForeignKey("dbo.Produto", "gestor_produto_ID", "dbo.Gestor_P", "ID");
            CreateIndex("dbo.Produto", "gestor_produto_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Produto", new[] { "gestor_produto_ID" });
            DropForeignKey("dbo.Produto", "gestor_produto_ID", "dbo.Gestor_P");
            DropColumn("dbo.Produto", "gestor_produto_ID");
            DropTable("dbo.Gestor_P");
        }
    }
}
