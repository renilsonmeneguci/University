namespace University.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inscricoes", "Curso_CursoId", "dbo.Cursos");
            DropIndex("dbo.Inscricoes", new[] { "Curso_CursoId" });
            RenameColumn(table: "dbo.Inscricoes", name: "Curso_CursoId", newName: "CursoId");
            AlterColumn("dbo.Inscricoes", "CursoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Inscricoes", "CursoId");
            AddForeignKey("dbo.Inscricoes", "CursoId", "dbo.Cursos", "CursoId", cascadeDelete: true);
            DropColumn("dbo.Inscricoes", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inscricoes", "CourseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Inscricoes", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Inscricoes", new[] { "CursoId" });
            AlterColumn("dbo.Inscricoes", "CursoId", c => c.Int());
            RenameColumn(table: "dbo.Inscricoes", name: "CursoId", newName: "Curso_CursoId");
            CreateIndex("dbo.Inscricoes", "Curso_CursoId");
            AddForeignKey("dbo.Inscricoes", "Curso_CursoId", "dbo.Cursos", "CursoId");
        }
    }
}
