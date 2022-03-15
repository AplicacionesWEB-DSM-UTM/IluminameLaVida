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
    public class UsuarioController : ControllerBase
    {
        UsuarioRepository repository = new UsuarioRepository();

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
        public IActionResult Add(UsuarioRequest model)
        {
            var response = repository.Add(model);
            return Ok(response);
        }

        [HttpPut]
        //Este metodo sirve para editar los correos

        public IActionResult Edit(UsuarioRequest model)
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
usalo para probar las funciones de Add y Edit:
{
    "idUsuario": 2,
    "idFoto": 3,
    "nombre": "Luis",
    "apellido": "Pool",
    "correo": "luis@outlook.es",
    "contraseña": "0987654321",
    "fotoRequest": {
        "idFoto": 3,
        "nombre": "hola",
        "url": "hola.jpg"
    }
}
*/
}

