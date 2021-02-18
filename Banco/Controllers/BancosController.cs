using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Contexto;
using ApiRest.DTO;
using ApiRest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BancosController : ControllerBase
    {
        private IBancosServices _bancosServices;

        
        public BancosController(IBancosServices bancosServices)
        {
            this._bancosServices = bancosServices;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Bancos dto)
        {
            if (string.IsNullOrEmpty(dto.nombre.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_bancosServices.Insert(dto));
        }

        [HttpPost]
        public IActionResult Actualizar(Bancos dto)
        {
            if (string.IsNullOrEmpty(dto.nombre.ToString()))
            {
                BadRequest("error con los parametros enviados");
            }
            return Ok(_bancosServices.Actualizar(dto));
        }

        [HttpGet]
        public IActionResult Listar()
        {

            return Ok(_bancosServices.Listar());
        }




    }
}
