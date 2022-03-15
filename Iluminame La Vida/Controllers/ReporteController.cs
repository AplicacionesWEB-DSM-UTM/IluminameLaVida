using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iluminame_La_Vida.Models.Request;
using Iluminame_La_Vida.Models.Repositories;

namespace Iluminame_La_Vida.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        ReporteRepository repository = new ReporteRepository();

        [HttpGet]
        //Consultar correos
        public IActionResult Get()
        {
            var response = repository.Get();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = repository.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        //Agregar usuario
        public IActionResult Add(ReporteRequest model)
        {
            var response = repository.Add(model);
            return Ok(response);
        }

        [HttpPut]
        //Este metodo sirve para editar los correos

        public IActionResult Edit(ReporteRequest model)
        {
            var response = repository.Edit(model);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        //Con este metodo vamos a eliminar cualquiera que querramos
        public IActionResult Delete(int id)
        {
            var response = repository.Delete(id);
            return Ok(response);
        }
    }
/*
{
    "IdReporte": 1,
    "IdEtiqueta": 1,
    "IdUsuario": 1,
    "IdFoto": 3,
    "IdGeoubicacion": 1,
    "Descripcion": "se rompio una bombilla en mi calle",
    "Fecha" : "2022-03-14",
    "GeoubicacionRequest": {
        "IdGeoubicacion": 1,
        "Latitud": 20.000999,
        "Longitud": -89.000999
    },
    "fotoRequest": {
        "idFoto": 3,
        "nombre": "falla",
        "url": "falla.jpg"
    }
}
*/
}
