using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseUno.Data.Entidades
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(150,MinimumLength = 3)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(350, MinimumLength = 10)]
        [Column(TypeName = "varchar")]
        public string Descripcion { get; set; }

        [Required]
        public double Precio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaLote { get; set; }
        
        public bool EnStock { get; set; }

    }
}
