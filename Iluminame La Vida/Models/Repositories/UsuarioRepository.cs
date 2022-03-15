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
    public class UsuarioRepository
    {
        FotoRepository foto = new FotoRepository();

        public Respuesta<List<UsuarioRequest>> Get()
        {
            Respuesta<List<UsuarioRequest>> oRespuesta = new Respuesta<List<UsuarioRequest>>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    var list = db.Usuarios.Join(db.Fotos, Usuario => Usuario.IdFoto, Foto => Foto.IdFoto, (Usuario, Foto) => new UsuarioRequest
                    {
                        IdUsuario = Usuario.IdUsuario,
                        IdFoto = Usuario.IdFoto,
                        Nombre = Usuario.Nombre,
                        Apellido = Usuario.Apellidos,
                        Correo = Usuario.Correo,
                        Contraseña = Usuario.Contraseña,
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
        public Respuesta<UsuarioRequest> GetById(int id)
        {
            Respuesta<UsuarioRequest> oRespuesta = new Respuesta<UsuarioRequest>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    var list = db.Usuarios.Join(db.Fotos, Usuario => Usuario.IdFoto, Foto => Foto.IdFoto, (Usuario, Foto) => new UsuarioRequest
                    {
                        IdUsuario = Usuario.IdUsuario,
                        IdFoto = Usuario.IdFoto,
                        Nombre = Usuario.Nombre,
                        Apellido = Usuario.Apellidos,
                        Correo = Usuario.Correo,
                        Contraseña = Usuario.Contraseña,
                        FotoRequest = new FotoRequest{
                            IdFoto = Foto.IdFoto,
                            Nombre = Foto.Nombre,
                            Url = Foto.Url,
                        }
                    }).FirstOrDefault(x => x.IdUsuario == id);
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
        public Respuesta<object> Add(UsuarioRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    Usuario oPro = new Usuario();
                    oPro.IdFoto = Convert.ToInt32(foto.Add(model.FotoRequest).Data);
                    oPro.Nombre = model.Nombre;
                    oPro.Apellidos = model.Apellido;
                    oPro.Correo = model.Correo;
                    oPro.Contraseña = model.Contraseña;
                    db.Usuarios.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oPro.IdUsuario;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return oRespuesta;
        }
        public Respuesta<object> Edit(UsuarioRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (IluminameContext db = new IluminameContext())
                {
                    foto.Edit(model.FotoRequest);

                    Usuario oPro = db.Usuarios.Find(model.IdUsuario);
                    oPro.IdFoto = model.IdFoto;
                    oPro.Nombre = model.Nombre;
                    oPro.Apellido = model.Apellido;
                    oPro.Correo = model.Correo;
                    oPro.Contraseña = model.Contraseña;

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
                    Usuario oPro = db.Usuarios.Find(id);

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
