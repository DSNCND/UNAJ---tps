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
        //le asigno una herramienta y un autobomba default para facilitar las pruebas ...
        Manguera manguera=new Manguera();
        Autobomba autobomba=new Autobomba();
        
        public Bombero(Manejador manejador):base(manejador)
        {
        	//este constructor no deberia estar disponible, solo existe con el proposito de facilitar el testing
        	//si no estubiera el siguiente construcotr me garantiza una instanciacion completa de sus campos
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
        	getVehiculo().conducir();
        	getVehiculo().encenderSirena();
        	Manguera m = (Manguera)getHerramienta();
        	m.usar();
            estrategia.ApagarIncendio(lugar, lugar.Calle);
            m.guardar();
        
        }
                
        public override void bajarGatito()
        {
            Console.WriteLine("bajando gatito");
        }
        
		//quite la interfaz observer
        /*public void alarmaDeIncendio(ILugar lugar)
        {
            this.apagarIncendio(lugar, lugar.Calle);

        }*/
    }
	
	

}
