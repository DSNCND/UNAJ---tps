/*
 * Created by SharpDevelop.
 * Date: 14/11/2019
 * Time: 04:33 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of IHerramienta.
	/// </summary>
	public interface IHerramienta
	{
		void usar();
		void guardar();
	}
	
	public class Manguera: IHerramienta
	{
		public void usar()
		{
			Console.WriteLine("usando el/la {0}",this);
		}
		public void guardar()
		{
			Console.WriteLine("guardando el/la {0}",this);
		}
		public override string ToString()
		{
			string[] s = base.ToString().Split('.');
			string a = (s)[s.Length-1];
			return a;
		}
	}
	
	public class Desfibrilador: IHerramienta
	{
		public void usar()
		{
			Console.WriteLine("usando el/la {0}",this);
		}
		public void guardar()
		{
			Console.WriteLine("guardando el/la {0}",this);
		}
		public override string ToString()
		{
			string[] s = base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		}
	}
	
	public class Pistola: IHerramienta
	{
		public void usar()
		{
			Console.WriteLine("usando el/la {0}",this);
		}
		public void guardar()
		{
			Console.WriteLine("guardando el/la {0}",this);
		}
		public override string ToString()
		{
			string[] s =  base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		} 
	}
	
	public class Buscapolo: IHerramienta
	{
		public void usar()
		{
			Console.WriteLine("usando el/la {0}",this);
		}
		public void guardar()
		{
			Console.WriteLine("guardando el/la {0}",this);
		}
		public override string ToString()
		{
			string [] s = base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		}
	}
	
	
	public class Llave: IHerramienta
	{
		public void usar()
		{
			Console.WriteLine("usando el/la {0}",this);
		}
		public void guardar()
		{
			Console.WriteLine("guardando el/la {0}",this);
		}
		public override string ToString()
		{
			string [] s = base.ToString().Split('.');
			string a = s[s.Length-1];
			return a;
		}
	}
}
