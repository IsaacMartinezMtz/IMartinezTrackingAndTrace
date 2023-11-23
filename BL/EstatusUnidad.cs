using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstatusUnidad
    {
        public static ML.EstatusUnidad GetAll()
        {
            ML.EstatusUnidad estatusUnidad = new ML.EstatusUnidad();
            try
            {
                using(DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = context.GetAllEstatusUnidad().ToList();
                    if(query != null)
                    {
                        estatusUnidad.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.EstatusUnidad unidad = new ML.EstatusUnidad();
                            unidad.IdEstatus = obj.IdEstatus;
                            unidad.Estatus = obj.Estatus;

                            estatusUnidad.Objects.Add(unidad);
                        }
                        estatusUnidad.Correct = true;

                        
                    }
                    else
                    {
                        estatusUnidad.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                estatusUnidad.Correct = false;

            }
            return estatusUnidad;
        }
    }
}
