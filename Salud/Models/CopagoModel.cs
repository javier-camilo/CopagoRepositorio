using Entity;

namespace Salud.Models
{
    
    public class CopagoInputModel
    {
           public string IdentificacionPaciente { get; set; }
           public double ValorServicio { get; set; }  
           public double SalarioTrabajador { get; set; }
           
    }

    public class CopagoViewModel : CopagoInputModel
     {
        public CopagoViewModel()
        {

        }
        
        public CopagoViewModel(Copago copago)
        {
            IdentificacionPaciente = copago.IdentificacionPaciente;
            ValorServicio = copago.ValorServicio;
            SalarioTrabajador = copago.SalarioTrabajador;
            CopagoValor=copago.CopagoValor;
            Porcentaje=copago.Porcentaje;
        }
        public double CopagoValor { get; set; }
        public string Porcentaje { get; set; }
    }
    

}