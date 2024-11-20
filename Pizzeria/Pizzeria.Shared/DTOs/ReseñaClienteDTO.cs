using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pizzeria.Backend.DTOs
{
    public class ReseñaClienteDTO
    {
        public int Id { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; }
        public string IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
    }
}