namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updFaturaRetirarNumero : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Fatura", "numero");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fatura", "numero", c => c.Int(nullable: false));
        }
    }
}
