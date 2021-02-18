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
    public class MovimientosController : ControllerBase
    {
        private IMovimientosServices _movimientosServices;


        public MovimientosController(IMovimientosServices usuariosServices)
        {
            this._movimientosServices = usuariosServices;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] MovimientosTr dto)
        {
            if (string.IsNullOrEmpty(dto.cuenta.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_movimientosServices.Insert(dto));
        }
        [HttpGet]
        public IActionResult totMov()
        {
            return Ok(_movimientosServices.totMov());
        }

        [HttpPost]
        public IActionResult Actualizar(MovimientosTr dto)
        {
            if (string.IsNullOrEmpty(dto.cuenta.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_movimientosServices.Actualizar(dto));
        }

        [HttpGet]
        public IActionResult Listar()
        {

            return Ok(_movimientosServices.Listar());
        }

       /* [HttpGet]
        public IActionResult Recuperar()
        {

            return Ok(_movimientosServices.Recuperar());
        }*/
    }
}
