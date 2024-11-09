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
        [ForeignKey("Usuario")]

        public int ?IdUsuario { get; set; }

        [JsonIgnore]
        public Usuario ?Usuario { get; set; }
        public UserType UserType { get; set; }
    }
}


