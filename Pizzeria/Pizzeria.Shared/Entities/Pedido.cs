﻿using Pizzeria.Shared.Enums;
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
        public DateTime ?HoraEntrega { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Direccion { get; set; }

        public string Productos { get; set; }
        public double CostoTotal { get; set; }

        [ForeignKey("Trabajador")]
        public string ?IdTrabajador { get; set; }

        [ForeignKey("Promocion")]
        public int ?IdPromocion { get; set; }
        public string ?CedulaUsuario { get; set; }

        [JsonIgnore]
        public User ?Users { get; set; }

        [JsonIgnore]
        public Trabajador ?Trabajador { get; set; }

        [JsonIgnore]
        public Promocion ?Promocion { get; set; }

    
        [JsonIgnore]
        public ICollection<PagoEfectivo> ?PagoEfectivos { get; set; }
        
    }


}
