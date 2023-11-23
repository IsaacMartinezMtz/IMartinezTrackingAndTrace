using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Repartidor
    {
        public static ML.Repartidor GetAll()
        {
            ML.Repartidor repartidor = new ML.Repartidor();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "SELECT IdRepartidor, Nombre, ApellidoPaterno, ApellidoMaterno, Repartidor.IdUnidadAsignada, Telefono,FechaAIngreso, Fotografia, UnidadEntega.NumeroPlaca FROM Repartidor INNER JOIN UnidadEntega ON (Repartidor.IdUnidadAsignada = UnidadEntega.IdUnidad)";
                    SqlCommand cmd = new SqlCommand(query, contex);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if(dt.Rows.Count > 0)
                    {
                        repartidor.Objects = new List<object>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            ML.Repartidor repartidoG = new ML.Repartidor();
                            repartidoG.IdRepartidor = int.Parse(dr[0].ToString());
                            repartidoG.Nombre= dr[1].ToString();
                            repartidoG.ApellidoPaterno = dr[2].ToString();
                            repartidoG.ApellidoMaterno = dr[3].ToString();
                            repartidoG.UnidadEntrega = new ML.UnidadEntrega();
                            repartidoG.UnidadEntrega.IdUnidad = int.Parse(dr[4].ToString());
                            repartidoG.UnidadEntrega.NumeroPlaca = dr[5].ToString();
                            repartidoG.Telefono = dr[6].ToString();
                            repartidoG.FechaIngreso = DateTime.Parse(dr[7].ToString());
                            repartidoG.Imagen = dr[8].ToString();

                            repartidor.Objects.Add(repartidoG);


                        }
                        repartidor.Correct = true;
                    }
                }

            }catch (Exception ex)
            {
                repartidor.Correct = false;

            }
            return repartidor;
        }

        public static ML.Repartidor GetById(int IdRepartido)
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            try
            {
              using(SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "SELECT IdRepartidor, Nombre, ApellidoPaterno, ApellidoMaterno, Repartidor.IdUnidadAsignada, Telefono,FechaAIngreso, Fotografia, UnidadEntega.NumeroPlaca FROM Repartidor INNER JOIN UnidadEntega ON (Repartidor.IdUnidadAsignada = UnidadEntega.IdUnidad) where IdRepartidor = @IdRepartidor";
                    SqlCommand cmd = new SqlCommand(query, contex);
                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdRepartidor", SqlDbType.Int);
                    collection[0].Value = IdRepartido;
                    cmd.Parameters.Add(collection);
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tablaRepartidor = new DataTable();

                    adapter.Fill(tablaRepartidor);
                    if(tablaRepartidor.Rows.Count > 0)
                    {
                        DataRow row = tablaRepartidor.Rows[0];
                        ML.Repartidor repartidorG = new  ML.Repartidor();
                        repartidorG.IdRepartidor = int.Parse(row[0].ToString());
                        repartidorG.Nombre = row[1].ToString();
                        repartidorG.ApellidoPaterno = row[2].ToString();
                        repartidorG.ApellidoMaterno = row[3].ToString();
                        repartidorG.UnidadEntrega = new ML.UnidadEntrega();
                        repartidorG.UnidadEntrega.IdUnidad = int.Parse(row[4].ToString());
                        repartidorG.UnidadEntrega.NumeroPlaca = row[5].ToString();
                        repartidorG.Telefono = row[6].ToString();
                        repartidorG.FechaIngreso =DateTime.Parse(row[7].ToString());
                        repartidorG.Imagen = row[8].ToString();

                        //boxing 
                        repartidor.Object = repartidorG;
                        repartidor.Correct = true;


                    }
                }  
            }
            catch (Exception ex)
            {
                repartidor.Correct = false;
            }
            return repartidor;
        }
        public static ML.Repartidor Add(ML.Repartidor repartidor)
        {
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "INSER INTO Repartidor VALUES (@Nombre, @ApellidoPaterno,@ApellidoMaterno, @IdUnidadAsignada, @Telefono, @FechaAIngreso, @Fotografia)";
                    SqlCommand cmd = new SqlCommand(query, contex);
                    SqlParameter[] collection = new SqlParameter[7];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = repartidor.Nombre;
                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value= repartidor.ApellidoPaterno;
                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value= repartidor.ApellidoMaterno;
                    collection[3] = new SqlParameter("@IdUnidad", SqlDbType.Int);
                    collection[3].Value = repartidor.UnidadEntrega.IdUnidad;
                    collection[4] = new SqlParameter("@Telefono", SqlDbType.VarChar);
                    collection[3].Value = repartidor.Telefono;
                    collection[5] = new SqlParameter("@FechaAIngreso", SqlDbType.DateTime);
                    collection[5].Value = repartidor.FechaIngreso;
                    collection[6] = new SqlParameter("@Fotografia", SqlDbType.Image);
                    collection[6].Value = repartidor.Imagen;
                    cmd.Parameters.Add(collection);
                    cmd.Connection.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        repartidor.Correct = true;

                    }
                    else
                    {
                        repartidor.Correct = false;

                    }
                }
            }
            catch (Exception ex)
            {
                repartidor.Correct = false;

            }
            return repartidor;
        }
        public static ML.Repartidor Update(ML.Repartidor repartidor)
        {
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "UPDATE Repartidor SET Nombre = @Nombre, ApellidoPaterno = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno,IdUnidadAsignada = @IdUnidadAsignada, Telefono = @Telefono, FechaAIngreso = @FechaIngreso, Fotografia = @Fotografia WHERE IdRepartidor = @IdRepartidor";
                    SqlCommand cmd = new SqlCommand(query, contex);
                    SqlParameter[] param = new SqlParameter[8];
                    param[0] = new SqlParameter("@IdRepartidor", SqlDbType.Int);
                    param[0].Value = repartidor.IdRepartidor;
                    param[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    param[1].Value = repartidor.Nombre;
                    param[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    param[2].Value = repartidor.ApellidoPaterno;
                    param[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    param[3].Value = repartidor.ApellidoMaterno;
                    param[4] = new SqlParameter("@IdUnidadAsignada", SqlDbType.Int);
                    param[5].Value = repartidor.UnidadEntrega.IdUnidad;
                    param[6] = new SqlParameter("@Telefono", SqlDbType.VarChar);
                    param[6].Value = repartidor.Telefono;
                    param[7] = new SqlParameter("@Fotografia", SqlDbType.VarChar);
                    param[7].Value = repartidor.Imagen;
                     
                    cmd.Parameters.AddRange(param);
                    cmd.Connection.Open();
                    int filasafectadas = cmd.ExecuteNonQuery();

                    if(filasafectadas > 0)
                    {
                        repartidor.Correct = true;
                    }
                    else
                    {
                        repartidor.Correct = false;
                    }
                }
            }
            catch (Exception e)
            {
                repartidor.Correct=false;

            }
            return repartidor;  
        }

        public static ML.Repartidor Delete(int IdRepartidor)
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "DELETE FROM Repartidor WHERE IdRepartidor = @IdRepartidor";
                    SqlCommand cmd = new SqlCommand(query, contex);
                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdRepartidor", SqlDbType.Int);
                    collection[0].Value = IdRepartidor;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if(filasAfectadas > 0)
                    {
                        repartidor.Correct= true;

                    }
                    else
                    {
                        repartidor.Correct= false;
                    }
                }


                }
            catch (Exception e)
            {
                repartidor.Correct=false;
            }
            return repartidor;
        }
        public static ML.Repartidor GetUnidad(int IdUsuario)
        {
            ML.Repartidor repartidor= new ML.Repartidor();
            
            try
            {
                using (DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = context.GetUnidadUsuario(IdUsuario).FirstOrDefault();
                    repartidor.Object = new List<object>();
                    if (query != null)
                    {
                        ML.Repartidor repartidorG = new ML.Repartidor();
                        repartidorG.UnidadEntrega = new ML.UnidadEntrega();
                        repartidorG.UnidadEntrega.EstatusUnidad = new ML.EstatusUnidad();
                        repartidorG.Usuario = new ML.Usuario();
                        repartidorG.UnidadEntrega.NumeroPlaca = query.NumeroPlaca;
                        repartidorG.UnidadEntrega.Marca = query.Marca;
                        repartidorG.UnidadEntrega.Modelo = query.Modelo;
                        repartidorG.UnidadEntrega.EstatusUnidad.Estatus = query.Estatus;
                        repartidorG.Usuario.Nombre = query.Nombre;

                        repartidor.Object = repartidorG;
                        repartidor.Correct = true;

                    }
                    else
                    {
                        repartidor.Correct=false;
                    }
                    

                }
            }catch(Exception ex)
            {
                repartidor.Correct= false;
            }
            return repartidor;
        }

        
    }
}
