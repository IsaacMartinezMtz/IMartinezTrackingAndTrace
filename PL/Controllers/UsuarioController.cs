using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            
            ML.Usuario usuario= BL.Usuario.GetAll();
            if (usuario.Correct)
            {
                usuario.Usuarios = usuario.Objects;
                return View(usuario);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            ML.Rol rolG = BL.Rol.GetAll(); 
            if (IdUsuario != null)
            {
                ML.Usuario usuarioG = BL.Usuario.GetById(IdUsuario.Value);
                if (usuarioG.Correct)
                {
                    usuario = (ML.Usuario)usuarioG.Object;
                    usuario.Rol.Roles = rolG.Objects;
                }
            }
            else
            {
                usuario.Rol.Roles = rolG.Objects;
            }
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                ML.Usuario usuarioE = BL.Usuario.Add(usuario);
                if (usuarioE.Correct)
                {
                    ViewBag.Mensaje = "Se ha registrado correctamente el usuario";
                    ViewBag.Valido = false;
                }
                else 
                {
                    ViewBag.Mensaje = "Error al registrar el usuario";
                    ViewBag.Valido = false;
                }
                
            }
            else
            {
                ML.Usuario usuarioE = BL.Usuario.Update(usuario);
                if (usuarioE.Correct)
                {
                    ViewBag.Mensaje = "Se ha actualizado correctamente el usuario";
                    ViewBag.Valido = false;

                }
                else
                {
                    ViewBag.Mensaje = "Error al actualizar el usuario";
                    ViewBag.Valido = false;

                }
            }
            return PartialView("Modal");

        }
        public ActionResult Delete(int IdUsuario)
        {
            ML.Usuario usuario = BL.Usuario.Delete(IdUsuario);
            if(usuario.Correct)
            {
                ViewBag.Mensaje = "Se ha Eliminado correctamente el usuario";
                ViewBag.Valido = false;
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar el usuario";
                ViewBag.Valido = false;
            }
            return PartialView("Modal");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetEmail(ML.Usuario usuario)
        {
            string email = usuario.Email;
            string password = usuario.Password;

            usuario = BL.Usuario.GetEmail(email);
            //Session["idRol"] = usuario.Rol.IdRol;
            if (usuario.Correct) 
            {
                usuario = (ML.Usuario)usuario.Object;
                Session["idRol"] = usuario.Rol.IdRol;
                if (password == "12345")
                {
                    Session["IdUsuario"] = usuario.IdUsuario;
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    ViewBag.valido = true;
                    ViewBag.Mensaje = "Error contraseña incorrecta";
                }
            }
            else
            {
                ViewBag.valido = true;
                ViewBag.Mensaje = "Error contraseña incorrecta";
            }
            return PartialView("Modal");
        }

    }
}