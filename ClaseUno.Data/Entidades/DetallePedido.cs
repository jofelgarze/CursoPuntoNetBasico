using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseUno.Data.Entidades
{
    public class DetallePedido
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public Producto Producto { get; set; }

        [Required]
        public Pedido Pedido { get; set; }

        [NotMapped]
        public double TotalDetalle { 
            get {
                return Producto.Precio * Cantidad;
            }
        }

    }
}
