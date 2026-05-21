namespace Estoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Produtoes SET Nome = 'Sem nome' WHERE Nome IS NULL");
            AlterColumn("dbo.Produtoes", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Produtoes", "Descricao", c => c.String(maxLength: 300));
            AlterColumn("dbo.Produtoes", "ImagemUrl", c => c.String(maxLength: 500));
        }

        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "ImagemUrl", c => c.String());
            AlterColumn("dbo.Produtoes", "Descricao", c => c.String());
            AlterColumn("dbo.Produtoes", "Nome", c => c.String());
        }
    }
}
