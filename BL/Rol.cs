using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Rol GetAll()
        {
            ML.Rol rol = new ML.Rol();
            try
            {
                using(DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities()) 
                {
                    var query = context.RolGetAll().ToList();
                    if (query != null)
                    {
                        rol.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Rol rolG = new ML.Rol();
                            rolG.IdRol = item.IdRol;
                            rolG.Tipo = item.Tipo;
                            rol.Objects.Add(rolG);
                        }
                        rol.Correct = true;
                    }
                    else
                    {
                        rol.Correct = false;
                    }
                }
            }catch (Exception ex)
            {
                rol.Correct = false;
            }
            return rol;
        }
    }
}
