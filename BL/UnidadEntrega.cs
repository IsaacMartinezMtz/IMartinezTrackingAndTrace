using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UnidadEntrega
    {
        public static ML.UnidadEntrega GetAll()
        {
            ML.UnidadEntrega unidadEntrega = new ML.UnidadEntrega();

            try
            {
                using (DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = (from UnidadEntregas in context.UnidadEntegas
                                 join EstatusUnidad in context.EstatusUnidads on UnidadEntregas.IdUnidad equals EstatusUnidad.IdEstatus
                                 select new
                                 {
                                     IdUnidad = UnidadEntregas.IdUnidad,
                                     NumeroPlaca = UnidadEntregas.NumeroPlaca,
                                     Modelo = UnidadEntregas.Modelo,
                                     Marca = UnidadEntregas.Marca,
                                     AnioFabricacion = UnidadEntregas.AnioFabricacion,
                                     IdEstatus = EstatusUnidad.IdEstatus,
                                     Estatus = EstatusUnidad.Estatus


                                 }).ToList();
                    unidadEntrega.Objects = new List<object>();

                    if (query.Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.UnidadEntrega unidad = new ML.UnidadEntrega();
                            unidad.IdUnidad = obj.IdUnidad;
                            unidad.NumeroPlaca = obj.NumeroPlaca;
                            unidad.Modelo = obj.Modelo;
                            unidad.Marca = obj.Marca;
                            unidad.AnioFabricacion = obj.AnioFabricacion;
                            unidad.EstatusUnidad.IdEstatus = obj.IdEstatus;
                            unidad.EstatusUnidad.Estatus = obj.Estatus;

                            unidadEntrega.Objects.Add(unidad);
                        }
                        unidadEntrega.Correct = true;
                    }
                    else
                    {
                        unidadEntrega.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                unidadEntrega.Correct = false;

            }
            return unidadEntrega;
        }
        public static ML.UnidadEntrega GetById(int IdUnidad)
        {
            ML.UnidadEntrega unidadEntrega = new ML.UnidadEntrega();
            try
            {
                using (DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = (from UnidadEntregas in context.UnidadEntegas
                                 join EstatusUnidad in context.EstatusUnidads on UnidadEntregas.IdUnidad equals EstatusUnidad.IdEstatus
                                 where UnidadEntregas.IdUnidad == IdUnidad
                                 select new
                                 {
                                     IdUnidad = UnidadEntregas.IdUnidad,
                                     NumeroPlaca = UnidadEntregas.NumeroPlaca,
                                     Modelo = UnidadEntregas.Modelo,
                                     Marca = UnidadEntregas.Marca,
                                     AnioFabricacion = UnidadEntregas.AnioFabricacion,
                                     IdEstatus = EstatusUnidad.IdEstatus,
                                     Estatus = EstatusUnidad.Estatus
                                 }
                                 );
                    unidadEntrega.Object = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.UnidadEntrega unidad = new ML.UnidadEntrega();
                            unidad.IdUnidad = obj.IdUnidad;
                            unidad.NumeroPlaca = obj.NumeroPlaca;
                            unidad.Modelo = obj.Modelo;
                            unidad.Marca = obj.Marca;
                            unidad.AnioFabricacion = obj.AnioFabricacion;
                            unidad.EstatusUnidad.IdEstatus = obj.IdEstatus;
                            unidad.EstatusUnidad.Estatus = obj.Estatus;

                            unidadEntrega.Object = unidad;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                unidadEntrega.Correct = false;
            }
            return unidadEntrega;
        }
        public static ML.UnidadEntrega Add(ML.UnidadEntrega unidadEntrega)
        {
            try
            {
                using(DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    DL.UnidadEntega add = new DL.UnidadEntega();
                    add.NumeroPlaca = unidadEntrega.NumeroPlaca;
                    add.Modelo = unidadEntrega.Modelo;
                    add.Marca = unidadEntrega.Marca;
                    add.AnioFabricacion = unidadEntrega.AnioFabricacion;
                    add.IdEstatusUnidad = unidadEntrega.EstatusUnidad.IdEstatus;

                    context.UnidadEntegas.Add(add);

                    int filaAfectadas = context.SaveChanges();

                    if (filaAfectadas > 0) unidadEntrega.Correct = true;
                    else
                    {
                        unidadEntrega.Correct = false;
                    }
                }

            }catch (Exception ex)
            {
                unidadEntrega.Correct=false;
            }
            return unidadEntrega;
        }
        public static ML.UnidadEntrega Delete(int IdUnidad)
        {
            ML.UnidadEntrega unidadEntrega = new ML.UnidadEntrega();

            try
            {
                using(DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = (from unidaEntrega in context.UnidadEntegas
                                 where unidaEntrega.IdUnidad == IdUnidad
                                 select unidaEntrega).SingleOrDefault();//se realiza un getById para consuktar el dato al elimninar 
                    if(query != null)
                    {
                        context.UnidadEntegas.Remove(query);
                        context.SaveChanges();
                        unidadEntrega.Correct = true;

                    }
                    else
                    {
                        unidadEntrega.Correct = false;
                    }
                }

            }catch(Exception ex)
            {
                unidadEntrega.Correct = false;
            }
            return unidadEntrega;
        }
        public static ML.UnidadEntrega Update(ML.UnidadEntrega unidadEntrega)
        {
            try
            {
                using(DL.TrackingAndTraceEntities context = new DL.TrackingAndTraceEntities())
                {
                    var query = (from a in context.UnidadEntegas where  a.IdUnidad == unidadEntrega.IdUnidad select a).SingleOrDefault();
                    if (query != null)
                    {
                        query.NumeroPlaca = unidadEntrega.NumeroPlaca;
                        query.Modelo = unidadEntrega.Modelo;
                        query.Marca = unidadEntrega.Marca;
                        query.AnioFabricacion = unidadEntrega.AnioFabricacion;
                        query.IdEstatusUnidad = unidadEntrega.EstatusUnidad.IdEstatus;

                        unidadEntrega.Correct = true;
                    }
                    else
                    {
                        unidadEntrega.Correct = false;
                    }
                }

            }catch(Exception ex)
            {
                unidadEntrega.Correct=false;

            }
            return unidadEntrega;
        }
    }
}
