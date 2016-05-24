namespace Bombando.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campoDataNaPostagem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Postagems", "Titulo", c => c.String(nullable: false));
            AlterColumn("dbo.Postagems", "Descricao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Postagems", "Descricao", c => c.String());
            AlterColumn("dbo.Postagems", "Titulo", c => c.String());
        }
    }
}
