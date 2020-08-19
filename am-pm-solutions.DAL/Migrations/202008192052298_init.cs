namespace am_pm_solutions.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblBolsaTrabajo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        NombreApellido = c.String(nullable: false, maxLength: 100),
                        Localidad = c.String(nullable: false, maxLength: 100),
                        Provincia = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 80),
                        NombreArchivoCV = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblContactos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaContacto = c.DateTime(nullable: false),
                        NombreApellido = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 80),
                        Mensaje = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblContactos");
            DropTable("dbo.tblBolsaTrabajo");
        }
    }
}
