
using System;
using HeroesDeCiudad.Patrones;

namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of IVehiculo.
	/// </summary>
	
	public interface IVehiculo
	{
		void encenderSirena();
		void conducir();
	}
	
	public abstract class Motorizado:IVehiculo
	{
		Estado estadoDelMotor;
		Random random = new Random();
		public Motorizado()
		{
			this.estadoDelMotor=new Apagado(this);
		}
		
		public virtual void setEstado(Estado estadoDelMotor)
		{
			this.estadoDelMotor=estadoDelMotor;
		}
		public virtual Estado getEstado()
		{
			return this.estadoDelMotor;
		}
	
		public virtual void encenderSirena()
		{
			Console.WriteLine("La {0} no tiene sirena ",this);
		}
		public void conducir()
		{
			int probabilidadEncendido = 80;
			int contador=5;
			Console.WriteLine("subiendo al {0} ", this);
			Console.WriteLine("Estado inicial: {0}",getEstado());
			while(random.Next(0,101)>probabilidadEncendido)
			{
				Console.WriteLine("intentando encender ...");
			}
			getEstado().encender();
			getEstado().acelerar();
			while(contador>0)
			{
				if(getEstado().ToString().ToUpper()=="MARCHALENTA")
				{
					getEstado().acelerar();
					contador--;
				}
				if(getEstado().ToString().ToUpper()=="MEDIAMARCHA")
				{
					if(random.Next(0,101)>30){
						getEstado().acelerar();
					}
					else{getEstado().desacelerar();}
					contador--;
				}
				if(getEstado().ToString().ToUpper()=="ATODAVELOCIDAD")
				{
					int tipo = 0;
					if(ToString().ToUpper()=="AMBULANCIA"||ToString().ToUpper()=="PATRULLERO"||ToString().ToUpper()=="AUTOBOMBA")tipo=10;
					if(random.Next(0,101)>(99-tipo))
					{
						getEstado().acelerar();
					}
					else{getEstado().desacelerar();}
					contador--;
				}
				if(getEstado().ToString().ToLower()=="roto"){contador=0;}//TODO podria llamar al mecanico para que arregle el motor
			}
			getEstado().frenar();
			Console.WriteLine(getEstado());
			getEstado().apagar();
			Console.ReadKey();
		}
		
		public override string ToString()
		{ 
			string[] s = base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		}
	}
	
	public class Autobomba:Motorizado,IVehiculo
	{
		public override void encenderSirena()
		{
			Console.WriteLine("Sirena del {0} encendida",this);
		}
	}
	
	public class Ambulancia:Motorizado, IVehiculo
	{
		public override void encenderSirena()
		{
			Console.WriteLine("Sirena de la {0} encendida",this);
		}
	}
	
	public class Patrullero:Motorizado, IVehiculo
	{
		public override void encenderSirena()
		{
			Console.WriteLine("Sirena del {0} encendida",this);
		}
	}
	
	public class Camioneta:Motorizado{}
	
}
