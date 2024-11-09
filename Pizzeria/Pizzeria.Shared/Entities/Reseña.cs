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
    public class Reseña
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Fecha de la Reña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaPublicacion { get; set; }

        [Display(Name = "Calificacion de la Reseña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public int Calificacion { get; set; }

        [Display(Name = "Comentario de la reseña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string  ?Comentario { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [JsonIgnore]
        public Usuario ?Usuario { get; set; }



    }
}
