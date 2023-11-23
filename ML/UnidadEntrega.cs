using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class UnidadEntrega
    {
        public int IdUnidad { get; set; }
        public string NumeroPlaca { get; set;}
        public string Modelo { get; set;}
        public string Marca { get; set;}
        public string AnioFabricacion { get; set;}
        public List<object> Unidades { get; set;}

        public ML.EstatusUnidad EstatusUnidad { get; set; }
        public bool Correct { get; set; }
        public List<object> Objects { get; set; }
        public object Object { get; set; }

    }
}
