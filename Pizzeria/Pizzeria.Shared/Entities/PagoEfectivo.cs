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
    public class PagoEfectivo
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Fecha de Pago")]
 
        public DateTime ?FechaPago { get; set; }

        [Display(Name = "Estado del Pago")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool Estado { get; set; }// Aprobado, pendiente y cancelado

        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        
        [JsonIgnore]
        public Pedido ?Pedido { get; set; }

    }
}
