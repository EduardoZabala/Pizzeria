using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pizzeria.Shared.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Cedula del Usuario")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Direccion { get; set; }

        [JsonIgnore]
        public ICollection<Pedido> ?Pedidos { get; set; }

        [JsonIgnore]
        public ICollection<Reseña> ?Reseñas { get; set; }
    }
}
