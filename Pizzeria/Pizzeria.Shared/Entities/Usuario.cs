using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pizzeria.Shared.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Cedula del Usuario")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ?Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ?Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int  ?Telefono { get; set; }
        
        [JsonIgnore]
        public ICollection<Trabajador> Trabajadores { get; set;}


        [JsonIgnore]
        public ICollection<Administrador> Administradores { get; set; }

    }
}
