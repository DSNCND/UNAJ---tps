
using System;

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
	
	public class Autobomba:IVehiculo
	{
		public void encenderSirena()
		{
			Console.WriteLine("Sirena del {0} encendida",this);
		}
		public void conducir()
		{
			Console.WriteLine("Conduciendo el {0} ", this);
		}
		
		public override string ToString()
		{ 
			string[] s = base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		}
	}
	public class Ambulancia:IVehiculo
	{
		public void encenderSirena()
		{
			Console.WriteLine("Sirena de la {0} encendida",this);
		}
		public void conducir()
		{
			Console.WriteLine("Conduciendo la {0} ", this);
		}
		
		public override string ToString()
		{
			string[] s = base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		}
	}
	public class Patrullero:IVehiculo
	{
		public void encenderSirena()
		{
			Console.WriteLine("Sirena del {0} encendida",this);
		}
		public void conducir()
		{
			Console.WriteLine("Conduciendo el {0} ", this);
		}
		
		public override string ToString()
		{
			string[] s = base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		}
	}
	public class Camioneta:IVehiculo
	{
		public void encenderSirena()
		{
			Console.WriteLine("La {0} no tiene sirena ",this);
		}
		public void conducir()
		{
			Console.WriteLine("Conduciendo la {0} ", this);
		}
		
		public override string ToString()
		{
			string[] s = base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		}
	}
	
}
