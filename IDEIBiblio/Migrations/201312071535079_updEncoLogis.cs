namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updEncoLogis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encomenda", "logistica_ID", c => c.Int());
            AddForeignKey("dbo.Encomenda", "logistica_ID", "dbo.Logistica", "ID");
            CreateIndex("dbo.Encomenda", "logistica_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Encomenda", new[] { "logistica_ID" });
            DropForeignKey("dbo.Encomenda", "logistica_ID", "dbo.Logistica");
            DropColumn("dbo.Encomenda", "logistica_ID");
        }
    }
}
