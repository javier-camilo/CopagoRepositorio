using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;
using System;


namespace Datos
{
    public class CopagoRepository
    {

         
        private readonly SqlConnection _connection;
        private readonly List<Copago> Copagos = new List<Copago>();

         public CopagoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }


         public void Guardar(Copago copago)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Copago (IdentificacionPaciente,ValorServicio,SalarioTrabajador,CopagoValor,Porcentaje) 
                                        values (@IdentificacionPaciente,@ValorServicio,@SalarioTrabajador,@CopagoValor,@Porcentaje)";
                command.Parameters.AddWithValue("@IdentificacionPaciente", copago.IdentificacionPaciente);
                command.Parameters.AddWithValue("@ValorServicio", copago.ValorServicio);
                command.Parameters.AddWithValue("@SalarioTrabajador", copago.SalarioTrabajador);
                command.Parameters.AddWithValue("@CopagoValor", copago.CopagoValor);
                command.Parameters.AddWithValue("@Porcentaje", copago.Porcentaje);
                var filas = command.ExecuteNonQuery();
            }
        }

         public List<Copago> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Copago> copagos = new List<Copago>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Copago ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Copago copago = DataReaderMap(dataReader);
                        copagos.Add(copago);
                    }
                }
            }
            return copagos;
        }

       private Copago DataReaderMap(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Copago copago = new Copago();
            copago.IdentificacionPaciente = (string)dataReader["IdentificacionPaciente"];
            copago.ValorServicio =(decimal)dataReader["ValorServicio"];
            copago.SalarioTrabajador =(decimal)dataReader["SalarioTrabajador"];
            decimal valor = copago.CopagoValor;
            return copago;
            
         }
        
        
    }
}