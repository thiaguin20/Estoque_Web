namespace Estoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuarios_create : DbMigration
    {
        public override void Up()
        {
            Sql(@"
IF OBJECT_ID('dbo.Usuarios', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Usuarios
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        Email NVARCHAR(150) NOT NULL,
        SenhaHash NVARCHAR(64) NOT NULL,
        PodeAcessarAdmin BIT NOT NULL,
        DataCadastro DATETIME NOT NULL
    )
END");
        }
        
        public override void Down()
        {
            Sql(@"
IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Usuarios
END");
        }
    }
}
