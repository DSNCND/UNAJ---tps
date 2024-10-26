using System;
using System.Collections.Generic;
using System.Linq;
using HeroesDeCiudad.Patrones;
using HeroesDeCiudad.Heroes;



namespace HeroesDeCiudad.Lugares
{
    class Casa:ILugar,IPatrullable,IObservado
    {
        int numeroDePuerta { get; set; }
        double superficie {get;set;}
        int cantidadDeHabitantes { get; set; }
        Calle calle;
        List<IObservador> Observadores = new List<IObservador>();
        //List<IObservador> Bomberos = new List<IObservador>();
        int caudalDeLluvia = 0;
        int temperatura = 0; 
        int velocidadDeViento = 0;
        public directorDeSector director=null;

        /*
        public void agregarObservador(IObservador o)
        {
            Bomberos.Add(o);
        }
        public void quitarObservador()
        {
            Bomberos.RemoveAt(0);
        }*/
        
           
		public void agregarObservador(IObservador o)
        {
            Observadores.Add(o);
        }

        public void quitarObservador()
        {
            Observadores.RemoveAt(0);
        }
        
        public void afectaciones(int caudalDeLluvia,int temperatura,int velocidadDeViento)
        {
            this.caudalDeLluvia = caudalDeLluvia;
            this.temperatura = temperatura;
            this.velocidadDeViento = velocidadDeViento;
        }
        public Casa(directorDeSector director) {
			this.director=director;
        }

        public Casa(int numeroDePuerta,double superficie,int cantidadDeHabitantes, Calle calle, directorDeSector director)
        {
            this.numeroDePuerta = numeroDePuerta;
            this.superficie = superficie;
            this.cantidadDeHabitantes = cantidadDeHabitantes;
            this.Calle = calle;
            this.director=director;
        }

        public Calle Calle
        {
            get{ return this.calle; }
            set{ calle = value; }
        }

        public ISector[][] getSectores()
        {
        	return director.crearSectoresAfectados(caudalDeLluvia, temperatura, velocidadDeViento,superficie);
        }


        public void chispa(int caudalDeLluvia, int temperatura, int velocidadDeViento)
        {
        	((IDenuncias)(Observadores[0])).agregarDenuncia(new DenunciaDeIncendio(this));
        }

        public bool hayAlgoFueraDeLoNormal(Random random)
        {
            int probabilidad = 63;
            if (random.Next(0,101) < probabilidad) return true;
            return false;
        }
    }
}
