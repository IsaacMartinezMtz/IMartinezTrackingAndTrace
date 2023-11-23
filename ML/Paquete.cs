using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Paquete
    {
        public int? IdPaquete { get; set; }
        public string Detalle { get; set; }
        public Decimal Peso { get; set; }
        public string DirrecionOrigen { get; set; }
        public string DirrecionEntrega { get; set; }
        public DateTime FechaEstimadaEntega { get; set; }
        public string CodigoRasdtreo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public List<object> Paquetes { get; set; }
        public bool Correct { get; set; }
        public List<object> Objects { get; set; }
        public object Object { get; set; }
    }
}
