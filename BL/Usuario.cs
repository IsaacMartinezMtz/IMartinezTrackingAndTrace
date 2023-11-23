using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography;

using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Usuario GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
           
            try {
                using (DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = context.UsuarioGetAll().ToList();
                    if (query != null)
                    {
                        usuario.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.Usuario usuarioG = new ML.Usuario();
                            usuarioG.IdUsuario = obj.IdUsuario;
                            usuarioG.UserName = obj.UserName;
                            usuarioG.PasswordHash = obj.Password;
                            usuarioG.Rol = new ML.Rol();
                            usuarioG.Rol.IdRol = (int)obj.IdRol;
                            usuarioG.Email = obj.Email;
                            usuarioG.Nombre = obj.Nombre;
                            usuarioG.ApellidoPaterno = obj.ApellidoPaterno;
                            usuarioG.ApellidoMaterno = obj.ApellidoMaterno;

                            usuario.Objects.Add(usuarioG);

                        }
                        usuario.Correct = true;

                    }
                    else
                    {
                        usuario.Correct= false;
                    }

                }
            } catch (Exception ex)
            {
                usuario.Correct = false;
            }
            return usuario;
        }
        public static ML.Usuario Add(ML.Usuario usuario)
        {
            //string messageString = usuario.Password;
            //byte[] messageBytes = Encoding.UTF8.GetBytes(messageString);

            ////Create the hash value from the array of bytes.

            //usuario.PasswordHash = SHA256.HashData(messageBytes);
            try
            {
                using(DL.TrackingAndTraceEntities contex = new DL.TrackingAndTraceEntities())
                {
                    var query = contex.AddUsuario(usuario.UserName, usuario.Password, usuario.Rol.IdRol, usuario.Email, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno);
                    if (query > 0)
                    {
                        usuario.Correct= true;
                    }
                    else
                    {
                        usuario.Correct= false;
                    }
                }

            }catch (Exception ex)
            {
                usuario.Correct = false;
                
            }
            return usuario;
        }
        public static ML.Usuario Update (ML.Usuario usuario)
        {
            try
            {
                using(DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = context.UpdateUsuario(usuario.IdUsuario,usuario.UserName, usuario.Password, usuario.Rol.IdRol, usuario.Email, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno);
                    if (query > 0)
                    {
                        usuario.Correct= true;
                    }
                    else
                    {
                        usuario.Correct= false;
                    }
                }

            }catch(Exception ex)
            {
                usuario.Correct = false;
            }
            return usuario;
        }
        public static ML.Usuario Delete(int IdUsuario)
        {
            ML.Usuario usuario =new ML.Usuario();
            try
            {
                using(DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = context.DeleteUsuario(IdUsuario);
                    if (query > 0)
                    {
                        usuario.Correct= true;
                    }
                    else
                    {
                        usuario.Correct= false;
                    }
                }
            }catch (Exception ex)
            {
                usuario.Correct = false;
            }
            return usuario;
        }
        public static ML.Usuario GetById(int IdUsuario)
        {
            ML.Usuario usuario= new ML.Usuario();
            try
            {
                using(DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = context.UsuarioGetById(IdUsuario).FirstOrDefault();

                    usuario.Object = new List<object>();
                    if(query != null)
                    {
                        ML.Usuario usuarioG= new ML.Usuario();
                        usuarioG.IdUsuario = query.IdUsuario;
                        usuarioG.UserName = query.UserName;
                        usuarioG.PasswordHash = query.Password;
                        usuarioG.Rol = new ML.Rol();
                        usuarioG.Rol.IdRol = (int)query.IdRol;
                        usuarioG.Email = query.Email;
                        usuarioG.Nombre = query.Nombre;
                        usuarioG.ApellidoPaterno = query.ApellidoPaterno;
                        usuarioG.ApellidoMaterno = query.ApellidoMaterno;

                        usuario.Object = usuarioG;
                        usuario.Correct = true;

                    }
                    else
                    {
                        usuario.Correct= false;
                    }

                }
            }catch(Exception ex)
            {
                usuario.Correct = true;
            }
            return usuario;
        }

        public static ML.Usuario GetEmail(string email)
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using(DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = context.GetEmail(email).FirstOrDefault();
                    usuario.Object = new List<object>();
                    if(query != null)
                    {
                        ML.Usuario usuarioG = new ML.Usuario();
                        usuarioG.IdUsuario = query.IdUsuario;
                        usuarioG.Email = query.Email;
                        usuarioG.PasswordHash = query.Password;
                        usuarioG.Rol = new ML.Rol();
                        usuarioG.Rol.IdRol = (int)query.IdRol;

                        usuario.Object = usuarioG;
                        usuario.Correct = true;
                    }
                    else
                    {
                        usuario.Correct= false;
                    }
                }
            }
            catch(Exception ex) 
            {
                usuario.Correct = false; 
            
            }
            return usuario;
        }
    }
}
