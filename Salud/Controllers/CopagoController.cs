using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Salud.Models;




namespace Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopagoController : ControllerBase
    {
        private readonly CopagoService _copagoService;
        public IConfiguration Configuration { get; }

        public CopagoController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _copagoService = new CopagoService(connectionString);
        }

        [HttpPost]
        public ActionResult<CopagoViewModel> Post(CopagoInputModel copagoInput)
        {
            
            Copago copago = Mapear(copagoInput);
            var response = _copagoService.Guardar(copago);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
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