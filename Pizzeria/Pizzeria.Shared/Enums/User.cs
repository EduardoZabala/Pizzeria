using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Pizzeria.Shared.Entities;

namespace Pizzeria.Shared.Enums
{
    public class User:IdentityUser
    {
        
        public string Cedula {  get; set; }
        public string ?Nombre {  get; set; }
        public string ?Apellido{  get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion { get; set; }

        public UserType UserType { get; set; }
    }
}


