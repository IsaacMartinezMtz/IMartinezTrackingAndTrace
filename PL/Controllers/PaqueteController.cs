using BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PaqueteController : Controller
    {
        // GET: Paquete
        public ActionResult GetRastreo(ML.Paquete paqueteG)
        {
            ML.Paquete paquete= BL.Paquete.GetRastreo(paqueteG.CodigoRasdtreo);
            if (paquete.Correct)
            {
                paquete = (ML.Paquete)paquete.Object;
                return View(paquete);
            }
            else
            {
                return View();
            }           
        }
        public ActionResult Opciones()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddPaquete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPaquete(ML.Paquete paquete)
        {
            var send = BL.Email.sendMail(paquete);
            var enviar = BL.Mensaje.Enviar(paquete);
            ML.Paquete paquete2 = BL.Paquete.AddPaquete(paquete);
            
            if (paquete2.Correct)
            {
                ViewBag.Mensaje = "Se ha enviado el correo";
                ViewBag.valido = true;
            }
            else
            {
                ViewBag.Mensaje = "Error al enviar el Correo";
                ViewBag.valido = false;
            }
            return PartialView("Modal");
        }
       
        
    }
}