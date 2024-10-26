using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDeCiudad.Lugares;
using HeroesDeCiudad.Patrones;

namespace HeroesDeCiudad.Heroes
{
	class Policia: Manejador
    {
        List<IPatrullable> lugaresPatrullables = new List<IPatrullable>();
        ICommand comandoPush=new VozDeAlto();
        ICommand comandoPop=new Perseguir();
        Random random = new Random();
        
        Pistola pistola=new Pistola();
        Patrullero patrullero=new Patrullero();

        public Policia(Manejador manejador):base(manejador){}
        public Policia(Manejador manejador,Pistola pistola, Patrullero patrullero):base(manejador)
        {
        	this.pistola=pistola;
        	this.patrullero=patrullero;
        }
        
        public override IHerramienta getHerramienta()
        {
        	return pistola;
        }
        
        public void setHerramienta(Pistola pistola)
        {
        	this.pistola=pistola;
        }
		public override void setHerramienta(IHerramienta herramienta)
		{
			this.pistola = (Pistola)herramienta;
		}
			     
		public override IVehiculo getVehiculo()
		{
			return patrullero;
		}
		
		public void setVehiculo(Patrullero patrullero)
		{
			this.patrullero=patrullero;
		}
		public override void setVehiculo(IVehiculo vehiculo)
		{
			patrullero = (Patrullero)vehiculo;
		}
        
		
        public void setComandoPush(ICommand comandoPush)
        {
            this.comandoPush = comandoPush;
        }
        public void setComandoPop(ICommand comandoPop)
        {
            this.comandoPop = comandoPop;
        }

        public void setLugaresAPatrullar(IPatrullable lugar)
        {
            lugaresPatrullables.Add(lugar);
        }

        public List<IPatrullable> getLugaresAPatrullar()
        {
            return lugaresPatrullables;
        }
	
        public override void patrullarCalles(IPatrullable patrullable)
        {
        	getVehiculo().conducir();
        	getVehiculo().encenderSirena();
        	Console.WriteLine("patrullando calles");
            if (patrullable.hayAlgoFueraDeLoNormal(random))
            {
                this.comandoPop.comando();
                getHerramienta().usar();
                getHerramienta().guardar();
                detenerDelincuente();
            }
        }

        public override void detenerDelincuente()
        {
            Console.WriteLine("deteniendo delincuente");
        }

    }
}
