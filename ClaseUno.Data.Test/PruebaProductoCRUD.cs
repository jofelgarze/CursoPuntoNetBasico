using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaseUno.Data.Test
{
    [TestClass]
    public class PruebaProductoCRUD
    {


        [TestMethod]
        public void TestCreacionProducto()
        {
            //Inicializar el contexto de la base de datos
            TiendaContextoDb contextoDb = new TiendaContextoDb();

            //Generar un registro de producto en c#
            Entidades.Producto producto = new Entidades.Producto();
            //producto.Id - es autoincremental, por lo que no se la debe usar al crear un registro
            producto.Nombre = "Monitor de 20\" Sony";
            producto.Precio = 10.45;
            producto.EnStock = true;
            producto.FechaLote = DateTime.UtcNow;
            producto.Descripcion = "Pantalla Plana LCD";

            //Agregar el producto al contexto inicializado
            contextoDb.Productos.Add(producto);

            //Guardar los cambios en la DB
            contextoDb.SaveChanges();

            //Consultar registro de producto en la DB - que tenga mismo nombre y precio
            Entidades.Producto productoDb = null; 
            foreach (var item in contextoDb.Productos.ToList())
            {
                if (item.Nombre == producto.Nombre && item.Precio == producto.Precio) {
                    productoDb = item;
                    break;
                }
            }

            var productoDbLinQ = contextoDb.Productos
                .Where(item => item.Nombre == producto.Nombre && item.Precio == producto.Precio)
                .SingleOrDefault();

            //Validar que se trate del mismo registro
            Assert.IsTrue(productoDb != null, "El producto se creo con el codigo " + productoDb.Id);
            
        }



        [TestMethod]
        public void TestModificarProducto()
        {
            //Inicializar el contexto de la base de datos
            TiendaContextoDb contextoDb = new TiendaContextoDb();

            //Consultar en la base de datos el registro a modificar
            var productoDb = contextoDb.Productos
                .Where(item => item.Nombre == "Monitor de 20\" Sony" && item.Precio == 10.45)
                .SingleOrDefault();

            //Modificar las propiedades deseadas
            productoDb.Nombre = "Monitor 24\" Sony";
            productoDb.Precio = 10.34;

            //Guardar los cambios en la Base de Datos
            contextoDb.SaveChanges();
                       
            //Validar que se modifico correctamente el registro
            Assert.IsNotNull(contextoDb.Productos.Where(p => p.Nombre == productoDb.Nombre).SingleOrDefault());

        }
    }


}
