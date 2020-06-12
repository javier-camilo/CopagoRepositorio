using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class CopagoService
    {
        private readonly CopagoContext _context;
        public CopagoService(CopagoContext context)
        {
            _context=context;

        }

        public GuardarCopagoResponse Guardar(Copago copago)
        {
            try
            {
                var copagoBuscado = _context.Copagos.Find(copago.IdentificacionPaciente);

                if(copagoBuscado!=null){

                    return new GuardarCopagoResponse("Error la persona ya se encuentra registrada");
                }

                _context.Copagos.Add(copago);
                _context.SaveChanges();

                return new GuardarCopagoResponse(copago);
            }
            catch (Exception e)
            {
                return new GuardarCopagoResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public class GuardarCopagoResponse 
        {
            public GuardarCopagoResponse(Copago copago)
            {
                Error = false;
                Copago = copago;
            }
            public GuardarCopagoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Copago Copago { get; set; }
        }


        
         public List<Copago> ConsultarTodos()
        {
            List<Copago> copagos = _context.Copagos.ToList();
            return copagos;
        }
    }
}