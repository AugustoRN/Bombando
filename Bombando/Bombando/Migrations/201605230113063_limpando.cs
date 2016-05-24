namespace Bombando.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class limpando : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Usuarios", "IX_Name");
            AlterColumn("dbo.Usuarios", "Cpf", c => c.String(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Index2",
                        new AnnotationValues(oldValue: "IndexAnnotation: { Name: IX_Cpf, IsUnique: True }", newValue: null)
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Cpf", c => c.String(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Index2",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: IX_Cpf, IsUnique: True }")
                    },
                }));
            CreateIndex("dbo.Usuarios", "Nome", unique: true, name: "IX_Name");
        }
    }
}
