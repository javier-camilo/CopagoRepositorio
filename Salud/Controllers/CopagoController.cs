using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Salud.Models;
using Datos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Salud.Hubs;

namespace Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopagoController : ControllerBase
    {
        private readonly CopagoService _copagoService;
        private readonly IHubContext<SignalHub> _hubContext;

        public CopagoController(CopagoContext context,IHubContext<SignalHub> hubContext)
        {
            _copagoService= new CopagoService(context);
            _hubContext=hubContext;
        }

        [HttpPost]
        public async Task<ActionResult<CopagoViewModel>> Post(CopagoInputModel copagoInput)
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

            var copagoViewModel = new CopagoViewModel(response.Copago);
            await _hubContext.Clients.All.SendAsync("CopagoRegistrado", copagoViewModel);
            return Ok(copagoViewModel);
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