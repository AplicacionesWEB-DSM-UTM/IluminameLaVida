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
    public class EtiquetaRepository
    {
        FotoRepository foto = new FotoRepository();

        public Respuesta<List<EtiquetaRequest>> Get()
        {
            Respuesta<List<EtiquetaRequest>> oRespuesta = new Respuesta<List<EtiquetaRequest>>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    var list = db.Etiqueta.Join(db.Fotos, Etiqueta => Etiqueta.IdFoto, Foto => Foto.IdFoto, (Etiqueta, Foto) => new EtiquetaRequest
                    {
                        IdEtiqueta = Etiqueta.IdEtiqueta,
                        IdFoto = Etiqueta.IdFoto,
                        Nombre = Etiqueta.Nombre,
                        Descripcion = Etiqueta.Descripcion,
                        FotoRequest = new FotoRequest{
                            IdFoto = Foto.IdFoto,
                            Nombre = Foto.Nombre,
                            Url = Foto.Url,
                        }
                    }).ToList();
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
        public Respuesta<EtiquetaRequest> GetById(int id)
        {
            Respuesta<EtiquetaRequest> oRespuesta = new Respuesta<EtiquetaRequest>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    var list = db.Etiqueta.Join(db.Fotos, Etiqueta => Etiqueta.IdFoto, Foto => Foto.IdFoto, (Etiqueta, Foto) => new EtiquetaRequest
                    {
                        IdEtiqueta = Etiqueta.IdEtiqueta,
                        IdFoto = Etiqueta.IdFoto,
                        Nombre = Etiqueta.Nombre,
                        Descripcion = Etiqueta.Descripcion,
                        FotoRequest = new FotoRequest{
                            IdFoto = Foto.IdFoto,
                            Nombre = Foto.Nombre,
                            Url = Foto.Url,
                        }
                    }).FirstOrDefault(x => x.IdEtiqueta == id);
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
        public Respuesta<object> Add(EtiquetaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    Etiqueta oPro = new Etiqueta();
                    oPro.IdFoto = Convert.ToInt32(foto.Add(model.FotoRequest).Data);
                    oPro.Nombre = model.Nombre;
                    oPro.Descripcion = model.Descripcion;
                    db.Etiqueta.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oPro.IdEtiqueta;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Edit(EtiquetaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    foto.Edit(model.FotoRequest);

                    Etiqueta oPro = db.Etiqueta.Find(model.IdEtiqueta);
                    oPro.IdFoto = model.IdFoto;
                    oPro.Nombre = model.Nombre;
                    oPro.Descripcion = model.Descripcion;

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
                    var idfoto = Convert.ToInt32(GetById(id).Data.IdFoto);
                    Etiqueta oPro = db.Etiqueta.Find(id);

                    db.Remove(oPro);
                    db.SaveChanges();

                    foto.Delete(idfoto);
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
