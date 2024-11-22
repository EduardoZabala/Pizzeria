using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.Shared.DTOs
{
    public class PagosDTO
    {
        public DateTime FechaPago { get; set; }
        public int pedidoId { get; set; }

        public string  Productos { get; set; }

        public string? PromocionNombre { get; set; }

        public string  Estado { get; set; }

        public double  CostoTotal { get; set; }

    }
}
