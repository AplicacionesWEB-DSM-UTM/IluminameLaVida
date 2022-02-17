using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Iluminame_La_Vida.Models.Response;
using Iluminame_La_Vida.Models;
using Iluminame_La_Vida.Models.Request;

namespace Iluminame_La_Vida.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        [HttpGet]
        //consultar reportes
        public IActionResult Get()
        {
            Respuesta<List<ReporteRequest>> oRespuesta = new Respuesta<List<ReporteRequest>>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    var list = db.Reportes.Join(db.Registros, Reporte => Reporte.IdUsuario, Registro => Registro.IdUsuario, (Reporte, Registro) => new ReporteRequest
                    {
                        Id_Reporte = Reporte.IdReporte,
                        Foto_Reporte = Reporte.FotoReporte,
                        DescripLugar = Reporte.DescripLugar,
                        Id_Etiqueta = Reporte.IdEtiqueta,
                        Id_Usuario = Registro.IdUsuario,
                        Coords = Reporte.Coords,
                        FechaDen = Reporte.FechaDen
                    }).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = list;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Respuesta<ReporteRequest> oRespuesta = new Respuesta<ReporteRequest>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    var list = db.Reportes.Join(db.Registros, Reporte => Reporte.IdUsuario, Registro => Registro.IdUsuario, (Reporte, Registro) => new ReporteRequest
                    {
                        Id_Reporte = Reporte.IdReporte,
                        Foto_Reporte = Reporte.FotoReporte,
                        DescripLugar = Reporte.DescripLugar,
                        Id_Etiqueta = Reporte.IdEtiqueta,
                        Id_Usuario = Registro.IdUsuario,
                        Coords = Reporte.Coords,
                        FechaDen = Reporte.FechaDen
                    }).FirstOrDefault(x => x.Id_Reporte == id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = list;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        //con esto vamos a agregar reportes
        public IActionResult Add(ReporteRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Reporte oPro = new Reporte();
                    oPro.IdUsuario = model.Id_Usuario;
                    oPro.IdEtiqueta = model.Id_Etiqueta;
                    oPro.FechaDen = model.FechaDen;
                    oPro.DescripLugar = model.DescripLugar;
                    oPro.Coords = model.Coords;
                    oPro.FotoReporte = model.Foto_Reporte;
                    db.Reportes.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    

        [HttpPut]

        //Este metodo sirve para editar los datos

        public IActionResult Edit(ReporteRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Reporte oPro = db.Reportes.Find(model.Id_Reporte);
                    oPro.DescripLugar = model.DescripLugar;
                    oPro.FotoReporte = model.Foto_Reporte;
                    oPro.IdEtiqueta = model.Id_Etiqueta;
                    oPro.IdUsuario = model.Id_Usuario;
                    oPro.Coords = model.Coords;
                    oPro.FechaDen = model.FechaDen;
                    db.Entry(oPro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        //Con este metodo vamos a eliminar cualquiera que querramos
        public IActionResult Del(int Id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (IluminameFinalContext db = new IluminameFinalContext())
                {
                    Reporte oPro = db.Reportes.Find(Id);
                    db.Remove(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}


