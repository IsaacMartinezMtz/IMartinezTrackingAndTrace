using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace PL.Controllers
{
    public class RepartidorController : Controller
    {
        // GET: Repartidor
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            ServiceReference1.RepartidorServiceClient repartidorWCF = new ServiceReference1.RepartidorServiceClient();
            // se llama servicio 
            var result = repartidorWCF.GetAll(repartidor);
            if (result.Correct) {
                repartidor.Repartidores = result.Objects.ToList();
            }
            else
            {
                return View();
            }
            return View(repartidor);
        }
        [HttpGet]
        public ActionResult Form(int? IdRepartidor)
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            if(IdRepartidor != null)
            {
                ServiceReference1.RepartidorServiceClient RepartidorWCF = new ServiceReference1.RepartidorServiceClient();
                var result = RepartidorWCF.GetById(repartidor);
                if (result.Correct)
                {
                    repartidor = (ML.Repartidor)result.Object;
                }
               
                
            }
            else
            {
                return View();
            }
            return View(repartidor);


        }
        [HttpPost]
        public ActionResult Form(ML.Repartidor repartidor)
        {
            if(repartidor.IdRepartidor == 0)
            {
                ServiceReference1.RepartidorServiceClient repartidorWCF = new ServiceReference1.RepartidorServiceClient();
                var result = repartidorWCF.Add(repartidor);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha registrado correctamente el repartidor ";
                }
                else
                {
                    ViewBag.Mensaje = "Error al registrar el repartidor";
                }

            }
            else
            {
                ServiceReference1.RepartidorServiceClient repartidorWCF = new ServiceReference1.RepartidorServiceClient();
                var result = repartidorWCF.Update(repartidor);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha actualizado correctamente el repartidor";

                }
                else 
                {
                    ViewBag.Mensaje = "Error al actualizar el repartidor";
                
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(ML.Repartidor repartidor)
        {
            ServiceReference1.RepartidorServiceClient repartidorWCF = new ServiceReference1.RepartidorServiceClient();
            var result = repartidorWCF.Delete(repartidor);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado correctamente el repartidor";

            }else
            {
                ViewBag.Mensaje = "Error al eliminar el repartidor";
            }
            return PartialView("Modal");
        }
        
    }
}