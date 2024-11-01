using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.Shared.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cedula { get; set; }

        [Display(Name = "Nombre del Usuario")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string  Nombre { get; set; } 

        [Display(Name = "Telefono del usuario")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Telefono { get; set; }

        [Display(Name = "Direccion del usuario")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Address { get; set; }
    }
}
