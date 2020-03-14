namespace ClaseUno.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetallePedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Pedido_Id = c.Int(nullable: false),
                        Producto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.Pedido_Id, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.Producto_Id, cascadeDelete: true)
                .Index(t => t.Pedido_Id)
                .Index(t => t.Producto_Id);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false, maxLength: 250, unicode: false),
                        Direccion = c.String(nullable: false, maxLength: 450, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 400, unicode: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 150, unicode: false),
                        Precio = c.Double(nullable: false),
                        FechaLote = c.DateTime(),
                        EnStock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallePedidoes", "Producto_Id", "dbo.Productoes");
            DropForeignKey("dbo.DetallePedidoes", "Pedido_Id", "dbo.Pedidoes");
            DropIndex("dbo.DetallePedidoes", new[] { "Producto_Id" });
            DropIndex("dbo.DetallePedidoes", new[] { "Pedido_Id" });
            DropTable("dbo.Productoes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.DetallePedidoes");
        }
    }
}
