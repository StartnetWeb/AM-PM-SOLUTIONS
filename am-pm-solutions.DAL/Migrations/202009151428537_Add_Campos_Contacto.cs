namespace am_pm_solutions.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Campos_Contacto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblContactos", "Direccion", c => c.String(nullable: false));
            AddColumn("dbo.tblContactos", "Pais", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblContactos", "Pais");
            DropColumn("dbo.tblContactos", "Direccion");
        }
    }
}
