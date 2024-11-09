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
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Hora Estimada de Entrega")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime HoraEntrega { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Direccion { get; set; }

        public double CostoTotal { get; set; }

        [ForeignKey("Trabajador")]
        public int IdTrabajador { get; set; }

        [ForeignKey("Promocion")]
        public int IdPromocion { get; set; }

        [ForeignKey("Usuario")]
        public int ?IdUsuario { get; set; }

        [JsonIgnore]
        public Usuario ?Usuario { get; set; }

        [JsonIgnore]
        public Trabajador ?Trabajador { get; set; }

        [JsonIgnore]
        public Promocion ?Promocion { get; set; }
    
        [JsonIgnore]
        public ICollection<PagoEfectivo> ?PagoEfectivos { get; set; }
        [JsonIgnore]
        public ICollection<Producto> ?Productos { get; set; }
    }


}
