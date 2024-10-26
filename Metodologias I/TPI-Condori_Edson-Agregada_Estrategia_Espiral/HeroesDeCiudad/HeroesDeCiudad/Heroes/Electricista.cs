using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDeCiudad.Lugares;

namespace HeroesDeCiudad.Heroes
{
	class Electricista: Manejador
    {
		Buscapolo buscapolo;
		Camioneta camioneta;
		
		
		public Electricista(Manejador manejador):base(manejador)
		{}
		public Electricista(Manejador manejador, Buscapolo buscapolo, Camioneta camioneta):base(manejador)
		{
			this.buscapolo = buscapolo;
			this.camioneta = camioneta;
		}
		
        public override IHerramienta getHerramienta()
        {
        	return buscapolo;
        }
        
        public void setHerramienta(Buscapolo buscapolo)
        {
        	this.buscapolo=buscapolo;
        }
		public override void setHerramienta(IHerramienta herramienta)
		{
			this.buscapolo = (Buscapolo)herramienta;
		}
			     
		public override IVehiculo getVehiculo()
		{
			return camioneta;
		}
		
		public void setVehiculo(Camioneta camioneta)
		{
			this.camioneta=camioneta;
		}
		public override void setVehiculo(IVehiculo vehiculo)
		{
			camioneta = (Camioneta)vehiculo;
		}
		
		
        public override void revisar(IIluminable iluminable)
        {
        	getVehiculo().encenderSirena();
        	getVehiculo().conducir();
        	if(((Motorizado)getVehiculo()).getEstado().ToString().ToLower()!="roto")
        	{
            Console.WriteLine("(electricista) revisando lamparas");
            getHerramienta().usar();
            iluminable.revisarYCambiarLamparasQuemadas();
            getHerramienta().guardar();
        	}//TODO else implementar la denuncia de pedido de un mecanico para arreglar el vehiculo si se rompe el motor. 
        }
    }
}
