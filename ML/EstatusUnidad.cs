using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class EstatusUnidad
    {
        public int IdEstatus { get; set; }
        public string Estatus { get; set; }

        public List<object> EstatusUnidadades {  get; set; }
        public bool Correct { get; set; }
        public List<object> Objects { get; set; }
        public object Object { get; set; }

    }
}
