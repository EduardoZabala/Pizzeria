using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.Shared.Entities
{
    public class Archivo
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string FileExtension { get; set; } = null!;
        public byte[] Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
