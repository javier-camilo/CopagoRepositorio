using Entity;
using System.ComponentModel.DataAnnotations;


namespace Salud.Models
{
    
    public class CopagoInputModel
    {
            [Required(ErrorMessage = "La identificacion es requerida")]
            [MaxLength(5,ErrorMessage="numero maximo es 5")]
           public string IdentificacionPaciente { get; set; }


           [Required(ErrorMessage = "el valor es requerido")]
        
           public double ValorServicio { get; set; }  


           [Required(ErrorMessage = "el salario es requerido")]

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