using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UnidadController : Controller
    {
        // GET: Unidad
        public ActionResult Vista()
        {
            int IdUsuario = Convert.ToInt16(Session["IdUsuario"]);

            ML.Repartidor repartidor= BL.Repartidor.GetUnidad(IdUsuario);
            if (repartidor.Correct)
            {
                repartidor = (ML.Repartidor)repartidor.Object;
                return View(repartidor);
            }
            else
            {
                return View();
            }
            
        }
    }
}