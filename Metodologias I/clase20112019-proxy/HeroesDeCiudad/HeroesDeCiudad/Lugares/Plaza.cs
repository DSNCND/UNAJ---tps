using System;
using System.Collections.Generic;
using HeroesDeCiudad.Patrones;
using HeroesDeCiudad.Heroes;

namespace HeroesDeCiudad.Lugares
{
    class Plaza:ILugar, IIluminable, IPatrullable,IObservado
    {
    	int caudalDeLluvia;
    	int temperatura;
    	int velocidadDeViento;
        string nombre { get; set; }
        double superficie;
        int cantidadArboles;
        int cantidadFarolas;
        Calle calle;
        List<IObservador> Observadores = new List<IObservador>();
        public directorDeSector director=null;

        public Calle Calle
        {
            get { return this.calle; }
            set { this.calle = value; }
        }
        public Plaza(directorDeSector director) {
        	this.director=director;
        }

        public Plaza(double superficie, Calle calle, int cantidadFarolas, int cantidadArboles, directorDeSector director )
        {
            this.superficie = superficie;
            this.calle = calle;
            this.cantidadFarolas = cantidadFarolas;
            this.cantidadArboles = cantidadArboles;
            this.director=director;
        }
		public void afectaciones(int caudalDeLluvia,int temperatura,int velocidadDeViento)
        {
            this.caudalDeLluvia = caudalDeLluvia;
            this.temperatura = temperatura;
            this.velocidadDeViento = velocidadDeViento;
        }
        
        public double Superficie 
        { 
        	get { return this.superficie; }
        	set { this.superficie = value; } 
        }
        public int CantidadArboles
        {
        	get { return cantidadArboles; }
            set { cantidadArboles = value; }
        }
        
        public int CantidadFarolas { get { return cantidadFarolas; }
            set { cantidadFarolas = value; }}

        public ISector[][] getSectores()
        {
        	//llamar a traves de director
        	//HACK arreglar variables de estado (objeto clima/obstaculos?)
        	return director.crearSectoresAfectados(40,90,10,Superficie);
        }

        
		public void agregarObservador(IObservador o)
        {
            Observadores.Add(o);
        }

        public void quitarObservador()
        {
            Observadores.RemoveAt(0);
        }


		public void chispa(int caudalDeLluvia, int temperatura, int velocidadDeViento)
        {
        	((IDenuncias)(Observadores[0])).agregarDenuncia(new DenunciaDeIncendio(this));
        }

        public void revisarYCambiarLamparasQuemadas()
        {
            Console.WriteLine("Cambiar luces //PLaza");
        }

        public bool hayAlgoFueraDeLoNormal(Random random)
        {
            const int probabilidad = 63;
            if (random.Next(0, 101) < probabilidad) return true;
            return false;
        }
        
		public override string ToString()
		{
			string [] s = base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		}
    }


}
