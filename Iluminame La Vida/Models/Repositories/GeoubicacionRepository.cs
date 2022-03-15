using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iluminame_La_Vida.Models.Data;
using Iluminame_La_Vida.Models.Response;
using Iluminame_La_Vida.Models.Request;

namespace Iluminame_La_Vida.Models.Repositories
{
    public class GeoubicacionRepository
    {
        public Respuesta<List<Geoubicacion>> Get()
        {
            Respuesta<List<Geoubicacion>> oRespuesta = new Respuesta<List<Geoubicacion>>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    var list = db.Geoubicacions.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = list;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<Geoubicacion> GetById(int id)
        {
            Respuesta<Geoubicacion> oRespuesta = new Respuesta<Geoubicacion>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    var list = db.Geoubicacions.Find(id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = list;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Add(GeoubicacionRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    Geoubicacion oPro = new Geoubicacion();
                    oPro.Latitud = model.Latitud;
                    oPro.Longitud = model.Longitud;
                    db.Geoubicacions.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oPro.IdGeoubicacion;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Edit(GeoubicacionRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    Geoubicacion oPro = db.Geoubicacions.Find(model.IdGeoubicacion);
                    oPro.Latitud = model.Latitud;
                    oPro.Longitud = model.Longitud;

                    db.Entry(oPro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Delete(int id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    Geoubicacion oPro = db.Geoubicacions.Find(id);
                    db.Remove(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
    }
}
