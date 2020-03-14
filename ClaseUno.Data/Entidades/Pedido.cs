using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseUno.Data.Entidades
{
    public class Pedido
    {
        public Pedido()
        {
            Detalles = new List<DetallePedido>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3)]
        [Column(TypeName = "varchar")]
        public string NombreCliente { get; set; }
        [Required]
        [StringLength(450, MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        public string Direccion { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 7)]
        [Column(TypeName = "varchar")]
        public string Telefono { get; set; }
        [Required]
        [MaxLength(400)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        [Required]
        public EstadoEnum Estado { get; set; }

        public List<DetallePedido> Detalles { get; set; }

        [NotMapped]
        public double Total {
            get {
                double total = 0;
                foreach (var item in Detalles)
                {
                    total += item.TotalDetalle;
                }
                return total;
            }  
        }
    }
}
