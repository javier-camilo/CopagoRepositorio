using Entity;

namespace Salud.Models
{
    
    public class CopagoInputModel
    {
           public string IdentificacionPaciente { get; set; }
           public decimal ValorServicio { get; set; }  
           public decimal SalarioTrabajador { get; set; }
           
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
        public decimal CopagoValor { get; set; }
        public string Porcentaje { get; set; }
    }
    

}