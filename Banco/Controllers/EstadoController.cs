using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.DTO;
using ApiRest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private IEstadoServices _bancosServices;


        public EstadoController(IEstadoServices bancosServices)
        {
            this._bancosServices = bancosServices;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Estado dto)
        {
            if (string.IsNullOrEmpty(dto.nombre.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_bancosServices.Insert(dto));
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] Estado dto)
        {
            if (string.IsNullOrEmpty(dto.nombre.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_bancosServices.Actualizar(dto));
        }

        [HttpDelete]
        public IActionResult Eliminar(int dto)
        {
            if (string.IsNullOrEmpty(dto.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_bancosServices.Eliminar(dto));
        }
        [HttpGet]
        public IActionResult Recuperar(int dto)
        {
            if (string.IsNullOrEmpty(dto.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_bancosServices.Recuperar(dto));
        }

        [HttpGet]
        public IActionResult Listar()
        {

            return Ok(_bancosServices.Listar());
        }
    }
}
