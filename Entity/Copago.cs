using System;


namespace Entity
{
    public class Copago
    {
        public string IdentificacionPaciente { get; set; }
        public decimal ValorServicio { get; set; }  
        public decimal SalarioTrabajador { get; set; }
        public string Porcentaje {get;set;}
        
        public decimal CopagoValor { 
            
            get
            {
                decimal valor,porcentaje=0.2m;

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