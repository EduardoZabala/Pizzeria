using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pizzeria.Shared.Entities
{
    public class Persona
    {

        [Key]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ?Nombre { get; set; }


        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        [JsonIgnore]
        public Administrador ?Administrador { get; set; }

        [JsonIgnore]
        public Trabajador? Trabajador { get; set; }

    }
}
