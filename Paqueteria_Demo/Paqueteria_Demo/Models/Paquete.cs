using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paqueteria_Demo.Models
{
    public class Paquete
    {
        public int cajon { get; set; }
        public string tracking { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public decimal precio { get; set; }
    }
}
