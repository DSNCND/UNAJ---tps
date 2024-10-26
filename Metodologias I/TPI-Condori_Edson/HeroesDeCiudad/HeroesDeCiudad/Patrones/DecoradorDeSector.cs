using System;
using HeroesDeCiudad.Lugares;

namespace HeroesDeCiudad.Patrones
{
    abstract class DecoradorDeSector : ISector
    {
        ISector sector=null;
            
        public DecoradorDeSector(ISector sector)
        {
            this.sector = sector;
        }

        public virtual void mojar(double agua)
        {
            sector.mojar(agua);
        }

        public bool EstaApagado()
        {
            return sector.EstaApagado();
        }

        public double GetPorcentajeDeAfectacion()
        {
           return sector.GetPorcentajeDeAfectacion();
        }

        public void SetPorcentajeDeAfectacion(double porcentaje)
        {
            sector.SetPorcentajeDeAfectacion(porcentaje);
        }
    }

    ///////////Decorados
    ///Dificultades

    class PastoSeco:DecoradorDeSector
    {
        public PastoSeco(ISector sector) : base (sector)
        {
        }
        public override void mojar(double agua)
        {
        	double a = agua/2;
            base.mojar(a);
        }
    }

    class ArbolesGrandes:DecoradorDeSector
    {
            
        public ArbolesGrandes(ISector sector) : base(sector)
        {
        }
        public override void mojar(double agua)
        {
        	double a = agua*0.25;
            base.mojar(a);
        }
    }

    class DiaDeMuchoCalor:DecoradorDeSector
    {
        int temperatura;

        public DiaDeMuchoCalor(ISector sector,int temperatura) : base(sector)
        {
            this.temperatura = temperatura;
        }
        public override void mojar(double agua)
        {
        	double a = agua-(0.1*temperatura);
            base.mojar(a);
        }

    }

    class DiaVentoso:DecoradorDeSector
    {
        int velocidadDelViento;
        public DiaVentoso(ISector sector,int velocidadDelViento) : base(sector)
        {
            this.velocidadDelViento = velocidadDelViento;
        }
        
        public override void mojar(double agua)
        {
        	double a = agua-(Math.Exp(velocidadDelViento/100));
            base.mojar(a);
        }
    }

    class GenteAsustada:DecoradorDeSector
    {
        int cantidadPersonas=0;
        public GenteAsustada(ISector sector,int cantidadPersonas) : base(sector)
        {
            this.cantidadPersonas = cantidadPersonas;
        }
        public override void mojar(double agua)
        {
            if (cantidadPersonas > 0)
            {
                agua = agua * 0.25;
                cantidadPersonas--;
            }
            base.mojar(agua);
        }
    }

    class DiaLluvioso:DecoradorDeSector
    {
        int intensidadDeLluvia;
        public DiaLluvioso(ISector sector,int intensidadDeLluvia) : base(sector)
        {
            this.intensidadDeLluvia = intensidadDeLluvia;
        }

        public override void mojar(double agua)
        {
        	double a = agua+intensidadDeLluvia;
            base.mojar(a);
        }
    }
}
