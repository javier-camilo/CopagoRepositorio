using Datos;
using Entity;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class CopagoService
    {
        
        private readonly ConnectionManager _conexion;
        private readonly CopagoRepository _repositorio;

        public CopagoService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new CopagoRepository(_conexion);
        }

        public GuardarCopagoResponse Guardar(Copago copago)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(copago);
                _conexion.Close();
                return new GuardarCopagoResponse(copago);
            }
            catch (Exception e)
            {
                return new GuardarCopagoResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
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
            _conexion.Open();
            List<Copago> copagos = _repositorio.ConsultarTodos();
            _conexion.Close();
            return copagos;
        }
    }
}