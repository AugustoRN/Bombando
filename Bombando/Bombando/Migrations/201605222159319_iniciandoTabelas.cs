namespace Bombando.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iniciandoTabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Postagems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descricao = c.String(),
                        Data = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Postagems", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Postagems", new[] { "UsuarioId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Postagems");
        }
    }
}
