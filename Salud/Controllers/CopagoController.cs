using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Salud.Models;
using Datos;
using Microsoft.AspNetCore.Http;

namespace Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopagoController : ControllerBase
    {
        private readonly CopagoService _copagoService;

        public CopagoController(CopagoContext context)
        {
            _copagoService= new CopagoService(context);
        }

        [HttpPost]
        public ActionResult<CopagoViewModel> Post(CopagoInputModel copagoInput)
        {
            
            Copago copago = Mapear(copagoInput);
            var response = _copagoService.Guardar(copago);
            if (response.Error) 
            {
                
                ModelState.AddModelError("Guardar Persona", response.Mensaje);

                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                return BadRequest(problemDetails);


            }

            return Ok(response.Copago);
        }

         private Copago Mapear(CopagoInputModel copagoInput)
        {
            var copago = new Copago
            {
                IdentificacionPaciente = copagoInput.IdentificacionPaciente,
                ValorServicio = copagoInput.ValorServicio,
                SalarioTrabajador = copagoInput.SalarioTrabajador
            };
            return copago;
        }

        [HttpGet]
        public IEnumerable<CopagoViewModel> Gets()
        {
            
            var personas = _copagoService.ConsultarTodos().Select(p=> new CopagoViewModel(p));
            return personas;
        }




        
    }
}