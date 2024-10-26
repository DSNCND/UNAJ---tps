using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDeCiudad.Patrones;

namespace HeroesDeCiudad.Heroes
{
	public class Medico: Manejador
    {
        IInfartable infartable;
        TemplateRCP RCP=new RCP2();
        Desfibrilador desfibrilador=new Desfibrilador();
        Ambulancia ambulancia=new Ambulancia();
        
        public Medico(Manejador manejador):base(manejador){}
	        
		public Medico(Manejador manejador, Desfibrilador desfibrilador, Ambulancia ambulancia):base(manejador)
		{
			this.desfibrilador = desfibrilador;
			this.ambulancia = ambulancia;
		}
		
        public override IHerramienta getHerramienta()
        {
        	return desfibrilador;
        }
        
        public void setHerramienta(Desfibrilador desfibrilador)
        {
        	this.desfibrilador=desfibrilador;
        }
		public override void setHerramienta(IHerramienta herramienta)
		{
			this.desfibrilador = (Desfibrilador)herramienta;
		}
			     
		public override IVehiculo getVehiculo()
		{
			return ambulancia;
		}
		
		public void setVehiculo(Ambulancia ambulancia)
		{
			this.ambulancia=ambulancia;
		}
		public override void setVehiculo(IVehiculo vehiculo)
		{
			ambulancia = (Ambulancia)vehiculo;
		}
		



        
        public void setRCP(TemplateRCP rcp)
        {
            this.RCP = rcp;
        }
        
        
        public override void atenderInfarto(IInfartable unTranseunte)
        {
        	
            this.infartable = unTranseunte;
            getVehiculo().encenderSirena();
            getVehiculo().conducir();
            if(((Motorizado)getVehiculo()).getEstado().ToString().ToLower()!="roto")
            {
            Console.WriteLine("atendiendo infarto");
            RCP.aplicarRCP(unTranseunte,this);
            }
        }
        
        public override void atenderDesmayo()
        {
        	Console.WriteLine("atendiendo desmayo");
        }
    }
}
