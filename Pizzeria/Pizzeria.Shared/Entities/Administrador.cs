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
    public class Administrador
    {
        [Key]
        [ForeignKey("Usuario")]
        public int Id { get; set; }

        [Display(Name = "Fecha del Ingreso del Administrador")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaIngreso { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }

    }
}
