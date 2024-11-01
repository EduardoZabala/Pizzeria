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
    public  class Trabajador
    {
        [Key]
        [ForeignKey("Usuario")]
        public int Cedula { get; set; }

        [Display(Name = "Turno del Trabajador")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ?Turno { get; set; }

        [Display(Name = "Salario del Trabajdor")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public double Salario { get; set; }
        
        
        [JsonIgnore]
        public Usuario ?Usuario { get; set; }

        [JsonIgnore]
        public ICollection<Pedido> ?Pedido { get; set; }
    }
}
