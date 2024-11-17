using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pizzeria.Shared.Entities
{
    public class Promocion
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre de la promocion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string nombre { get; set; }

        [Display(Name = "Descripcion de la promocion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; }

        [Display(Name = "Foto")]
        public string? Foto { get; set; }

        [Display(Name = "Valor del descuento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public double VlrDescuento { get; set; }   //VALOR O PORCENTAJE? REVISAR


        public bool Estado { get; set; }//Estado de la promocion Activo o inactiva

        [JsonIgnore]
        public ICollection<Pedido> ?Pedidos { get; set; }
    }
}