/*
 * Created by SharpDevelop.
 */
using System;
using HeroesDeCiudad.Heroes;

namespace HeroesDeCiudad.Patrones
{
	/// <summary>
	/// Description of Estado.
	/// </summary>
	public abstract class Estado
	{
		Motorizado vehiculo=null;
		
		public Estado(Motorizado vehiculo)
		{
			this.vehiculo=vehiculo;
		}
		protected Motorizado getVehiculo()
		{
			return this.vehiculo;
		}
		
		public virtual void encender()
		{
			Console.WriteLine("El vehiculo ya esta encendido");
		}
		public virtual void apagar()
		{
			Console.WriteLine("Se rompio el motor");
			vehiculo.setEstado(new Roto(getVehiculo()));
		}
		public virtual void acelerar()
		{
			Console.WriteLine("no puede acelerar el vehiculo, primero debe encenderlo");
		}
		public virtual void desacelerar()
		{
			Console.WriteLine("...");
		}
		public virtual void frenar()
		{
			Console.WriteLine("frenando...");
			getVehiculo().setEstado(new PuntoMuerto(getVehiculo()));
		}
		public virtual void arreglar()
		{
			Console.WriteLine("el motor no necesita ser arreglado");
		}
		
		
		public override string ToString()
		{
			string[] a = base.ToString().Split('.');
			string s = a[a.Length-1];
			return s;
		}
	}
	
	public class Apagado:Estado
	{
		public Apagado(Motorizado vehiculo):base(vehiculo){}
		
		public override void encender()
		{
			Console.WriteLine("encendiendo el motor");
			base.getVehiculo().setEstado(new PuntoMuerto(base.getVehiculo()));
		}
		public override void apagar()
		{
		Console.WriteLine("El motor ya esta apagado");
		}
		public override void frenar()
		{
			Console.WriteLine("...");
		}
		
	}
	
	public class PuntoMuerto:Estado
	{
		public PuntoMuerto(Motorizado vehiculo):base(vehiculo){}
		
		public override void apagar()
		{
			Console.WriteLine("apagando el motor");
			base.getVehiculo().setEstado(new Apagado(this.getVehiculo()));
		}
		public override void acelerar()
		{
			Console.WriteLine("Estado actual: {0}",this);
			base.getVehiculo().setEstado(new MarchaLenta(getVehiculo()));
			Console.WriteLine("Estado despues de acelerar: {0}",getVehiculo().getEstado());
		}
		
	}
	
	public class MarchaLenta:Estado
	{
		public MarchaLenta(Motorizado vehiculo):base(vehiculo){}
		
		public override void acelerar()
		{
			Console.WriteLine("Estado actual: {0}",this);
			base.getVehiculo().setEstado(new MediaMarcha(getVehiculo()));
			Console.WriteLine("Estado despues de acelerar: {0}",getVehiculo().getEstado());
		}
		public override void desacelerar()
		{
			Console.WriteLine("Estado actual: {0}",this);
			base.getVehiculo().setEstado(new PuntoMuerto(getVehiculo()));
			Console.WriteLine("Estado despues de desacelerar: {0}",getVehiculo().getEstado());
		}
		
	}
	
	public class MediaMarcha:Estado
	{
		public MediaMarcha(Motorizado vehiculo):base(vehiculo){}
		
		public override void acelerar()
		{
			Console.WriteLine("Estado actual: {0}",this);
			base.getVehiculo().setEstado(new ATodaVelocidad(getVehiculo()));
			Console.WriteLine("Estado despues de acelerar: {0}",getVehiculo().getEstado());
		}
		public override void desacelerar()
		{
			Console.WriteLine("Estado actual: {0}",this);
			base.getVehiculo().setEstado(new MarchaLenta(getVehiculo()));
			Console.WriteLine("Estado despues de desacelerar: {0}",getVehiculo().getEstado());
		}
		
	}
	
	public class ATodaVelocidad:Estado
	{
		public ATodaVelocidad(Motorizado vehiculo):base(vehiculo){}
		
		public override void acelerar()
		{
			Console.WriteLine("Estado actual: {0}",this);
			base.getVehiculo().setEstado(new Roto(getVehiculo()));
			Console.WriteLine("Estado despues de acelerar: {0}",getVehiculo().getEstado());
		}
		public override void desacelerar()
		{
			Console.WriteLine("Estado actual: {0}",this);
			base.getVehiculo().setEstado(new MediaMarcha(getVehiculo()));
			Console.WriteLine("Estado despues de desacelerar: {0}",getVehiculo().getEstado());
		}
	}
	
	public class Roto:Estado
	{
		public Roto(Motorizado vehiculo):base(vehiculo){}
		
		public override void encender()
		{
			Console.WriteLine("no se puede encender el motor, esta roto, llame a un mecanico.");
		}
		public override void apagar()
		{
			Console.WriteLine("llame a un mecanico ");
		}
		public override void frenar()
		{
			Console.WriteLine("... esta accion, no parece arreglar el motor");
		}
		public override void arreglar()
		{
			getVehiculo().setEstado(new Apagado(getVehiculo()));
		}
	}

}
