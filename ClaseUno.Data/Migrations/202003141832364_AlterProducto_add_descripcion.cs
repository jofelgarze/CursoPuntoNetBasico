namespace ClaseUno.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProducto_add_descripcion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Descripcion", c => c.String(nullable: false, maxLength: 350, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "Descripcion");
        }
    }
}
