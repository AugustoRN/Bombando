namespace Bombando.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class unicoos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Nome", c => c.String(nullable: false, maxLength: 200,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "IX_UNICO",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { }")
                    },
                }));
            AlterColumn("dbo.Usuarios", "Cpf", c => c.String());
            CreateIndex("dbo.Usuarios", "Nome", unique: true, name: "IX_UNICO");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuarios", "IX_UNICO");
            AlterColumn("dbo.Usuarios", "Cpf", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Nome", c => c.String(nullable: false, maxLength: 200,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "IX_UNICO",
                        new AnnotationValues(oldValue: "IndexAnnotation: { }", newValue: null)
                    },
                }));
        }
    }
}
