using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paquete
    {
        public static ML.Paquete GetRastreo(string Codigo)
        {
            ML.Paquete paquete = new ML.Paquete();
            try
            {
                using (DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = context.GetRastreo(Codigo).FirstOrDefault();
                    paquete.Object = new List<object>();
                    if (query != null)
                    {
                        ML.Paquete paqueteG = new ML.Paquete();
                        paqueteG.IdPaquete = query.IdPaquete;
                        paqueteG.Detalle = query.Detalle;
                        paqueteG.Peso = (decimal)query.Peso;
                        paqueteG.DirrecionOrigen = query.DirrecionOrigen;
                        paqueteG.DirrecionEntrega = query.DirrecionEntrega;
                        paqueteG.FechaEstimadaEntega = (DateTime)query.FechaEstimadaEntrega;
                        paqueteG.CodigoRasdtreo = query.CodigoRastreo;

                        paquete.Object = paqueteG;

                        paquete.Correct = true;
                    }
                }

            }catch (Exception ex)
            {
                paquete.Correct = false;

            }
            return paquete;
        }
        public static ML.Paquete AddPaquete( ML.Paquete paquete)
        {
            try
            {
                using(DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = context.AddPaquete(paquete.Detalle, paquete.Peso, paquete.DirrecionOrigen, paquete.DirrecionEntrega);
                    if(query > 0)
                    {
                        paquete.Correct = true;
                    }
                    else
                    {
                        paquete.Correct = false;
                    }
                }

            }catch (Exception ex)
            {
                paquete.Correct=false;
            }
            return paquete;
        }

    }
}
