namespace ClaseUno.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class TiendaContextoDb : DbContext
    {
        public TiendaContextoDb()
            : base("TiendaContextoDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<ClaseUno.Data.Entidades.Producto> Productos { get; set; }
        public virtual DbSet<ClaseUno.Data.Entidades.Pedido> Pedidos { get; set; }
        public virtual DbSet<ClaseUno.Data.Entidades.DetallePedido> DetallePedidos { get; set; }
    }

}