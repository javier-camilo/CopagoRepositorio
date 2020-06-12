using System;
using System.ComponentModel.DataAnnotations;


namespace Entity
{
    public class Copago
    {
        [Key]
        public string IdentificacionPaciente { get; set; }
        public double ValorServicio { get; set; }  
        public double SalarioTrabajador { get; set; }
        public string Porcentaje {get;set;}
        
        public double CopagoValor { 
            
            get
            {
                double valor,porcentaje=0.2;

                if (SalarioTrabajador>2500000)
                {
                    valor=this.ValorServicio*porcentaje;
                    this.Porcentaje="20";
                    
                }else {

                    valor=this.ValorServicio*porcentaje;
                    this.Porcentaje="10";
                }
                
                return valor;

            }

        }

    }
}