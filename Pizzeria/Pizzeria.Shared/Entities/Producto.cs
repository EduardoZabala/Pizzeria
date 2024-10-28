using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pizzeria.Shared.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Fecha del Ingreso del Administrador")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Precio del producto")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public double Precio { get; set; }

        [Display(Name = "Cantidad del producto")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Cantidad { get; set; }

        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }

        [JsonIgnore]
        public Pedido Pedido { get; set; }


    }
}
