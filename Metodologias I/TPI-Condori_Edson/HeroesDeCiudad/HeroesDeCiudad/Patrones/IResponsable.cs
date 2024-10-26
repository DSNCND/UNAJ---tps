/*
 * Created by SharpDevelop.
 */
 
using System;
using System.Collections.Generic;
using HeroesDeCiudad.Lugares;

namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of IResponsable.
	/// </summary>
	public interface IResponsable
	{

	}
	
	public abstract class Manejador:IResponsable
	{
		protected Manejador manejador = null;
		
		public Manejador(Manejador manejador)
		{
			this.manejador = manejador;
		}
		
		public override string ToString()
		{
			string[] s = base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		}
		
		public virtual IHerramienta getHerramienta(){return null;}
		public virtual void setHerramienta(IHerramienta herramienta){}
			     
		public virtual IVehiculo getVehiculo(){return null;}
		public virtual void setVehiculo(IVehiculo vehiculo){}
		
		
		virtual public void atenderInfarto(IInfartable victima)
		{
			if(manejador!=null)manejador.atenderInfarto(victima);
		}
		
		virtual public void atenderDesmayo()
		{
			if(manejador!=null)manejador.atenderDesmayo();
		}
		
		virtual public void patrullarCalles(IPatrullable patrullable)
		{
			if(manejador!=null)manejador.patrullarCalles(patrullable);
		}
		
		virtual public void detenerDelincuente()
		{
			if(manejador!=null)manejador.detenerDelincuente();
		}
		
		virtual public void revisar(IIluminable iluminable)
		{
			if(manejador!=null)manejador.revisar(iluminable);
		}
		
		virtual public void apagarIncendio(ILugar lugar)
		{
			if(manejador!=null)manejador.apagarIncendio(lugar);
		}
		
		virtual public void bajarGatito()
		{
			if(manejador!=null)manejador.bajarGatito();
		}
		
		virtual public void arreglarMotor(IVehiculo vehiculo)
		{
			if(manejador!=null)manejador.arreglarMotor(vehiculo);
		}
		virtual public void remolcarAuto(IVehiculo vehiculo)
		{
			if(manejador!=null)manejador.remolcarAuto(vehiculo);
		}
		
	}
}
