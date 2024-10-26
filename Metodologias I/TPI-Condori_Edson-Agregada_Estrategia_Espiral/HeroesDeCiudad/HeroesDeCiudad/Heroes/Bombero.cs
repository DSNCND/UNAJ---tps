using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HeroesDeCiudad.Lugares;
using HeroesDeCiudad.Patrones;
    

namespace HeroesDeCiudad.Heroes

{
	public class Bombero : Manejador
    {
        IStrategy estrategia = new Secuencial();
        Manguera manguera=new Manguera();
        Autobomba autobomba=new Autobomba();
        
        public Bombero(Manejador manejador):base(manejador)
        {
        }
        public Bombero(Manejador manejador, Manguera manguera, Autobomba autobomba):base(manejador)
		{
			this.manguera = manguera;
			this.autobomba = autobomba;
		}
        public void setManejador(Manejador manejador)
        {
        	base.manejador=manejador;
        }
        
		
        public override IHerramienta getHerramienta()
        {
        	return manguera;
        }
        
        public void setHerramienta(Manguera manguera)
        {
        	this.manguera=manguera;
        }
		public override void setHerramienta(IHerramienta herramienta)
		{
			this.manguera = (Manguera)herramienta;
		}
			     
		public override IVehiculo getVehiculo()
		{
			return this.autobomba;
		}
		
		public void setVehiculo(Autobomba autobomba)
		{
			this.autobomba=autobomba;
		}
		public override void setVehiculo(IVehiculo vehiculo)
		{
			autobomba = (Autobomba)vehiculo;
		}
		
                
        public void SetEstrategia(IStrategy estrategia)
        {
            this.estrategia = estrategia;
        }
        
        public override void apagarIncendio(ILugar lugar)
        {
        	getVehiculo().encenderSirena();
        	getVehiculo().conducir();
        	if(((Motorizado)getVehiculo()).getEstado().ToString().ToLower()!="roto")
        	{
        	getHerramienta().usar();
            estrategia.ApagarIncendio(lugar, lugar.Calle);
            getHerramienta().guardar();
        	}
        }
                
        public override void bajarGatito()
        {
            Console.WriteLine("bajando gatito");
        }
       
	}
}
