namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updncomenda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Encomenda", "compra_ID", "dbo.Compra");
            DropIndex("dbo.Encomenda", new[] { "compra_ID" });
            AddColumn("dbo.Encomenda", "Portes", c => c.Single(nullable: false));
            DropColumn("dbo.Encomenda", "compra_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Encomenda", "compra_ID", c => c.Int());
            DropColumn("dbo.Encomenda", "Portes");
            CreateIndex("dbo.Encomenda", "compra_ID");
            AddForeignKey("dbo.Encomenda", "compra_ID", "dbo.Compra", "ID");
        }
    }
}
