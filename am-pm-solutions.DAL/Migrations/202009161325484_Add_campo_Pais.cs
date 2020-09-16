namespace am_pm_solutions.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_campo_Pais : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblBolsaTrabajo", "País", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblBolsaTrabajo", "País");
        }
    }
}
