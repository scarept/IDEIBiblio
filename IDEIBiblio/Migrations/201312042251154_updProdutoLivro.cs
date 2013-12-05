namespace IDEIBiblio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updProdutoLivro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "titulo", c => c.String(nullable: false));
            AlterColumn("dbo.Produto", "editora", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "editora", c => c.String());
            AlterColumn("dbo.Produto", "titulo", c => c.String());
        }
    }
}
