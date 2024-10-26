
using System;
using System.Collections.Generic;

namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of ICuartel.
	/// </summary>
	public interface ICuartel
	{
		void agregarVehiculo(IVehiculo vehiculo);
		void agregarPersonal(IResponsable personal);
		void agregarHerramienta(IHerramienta herramienta);
		IResponsable getPersonal();
	}
	
	public abstract class Base:ICuartel
	{
		List<IResponsable> personal = new List<IResponsable>();
		List<IVehiculo> vehiculos = new List<IVehiculo>();
		List<IHerramienta> herramientas = new List<IHerramienta>() ;
		
		public void agregarPersonal(IResponsable personal)
		{
			this.personal.Add(personal);
		}
		public void agregarVehiculo(IVehiculo vehiculo)
		{
			this.vehiculos.Add(vehiculo);
		}
		public void agregarHerramienta(IHerramienta herramienta)
		{
			this.herramientas.Add(herramienta);
		}
		public IResponsable getPersonal()
		{
			Console.WriteLine(personal.Count+" - personal disponible - antes");
			Console.WriteLine(herramientas.Count+" - personal disponible - antes");
			Console.WriteLine(vehiculos.Count+" - personal disponible - antes");
			IResponsable persona = (Manejador)personal[0];
			personal.RemoveAt(0);
			((Manejador)persona).setHerramienta(herramientas[0]);
			herramientas.RemoveAt(0);
			((Manejador)persona).setVehiculo(vehiculos[0]);
			vehiculos.RemoveAt(0);
			
			Console.WriteLine(personal.Count+" - personal disponible - despues");
			Console.WriteLine(herramientas.Count+" - herramientas disponibles - despues");
			Console.WriteLine(vehiculos.Count+" - vehiculos disponibles - despues");
			return persona;
		}
	}
	public class CuartelDeBomberos:Base, ICuartel
	{
		static CuartelDeBomberos cuartel=null;
		
		CuartelDeBomberos(){}
		
		public static CuartelDeBomberos getInstanciaCuartel()
		{
			if(cuartel==null)
			{
				cuartel=new CuartelDeBomberos();
			}
			
			return cuartel;
		}
		
		public void agregarPersonal(Bombero bombero)
		{
			base.agregarPersonal(bombero);
		}
		public void agregarVehiculo(Autobomba unAutoBomba)
		{
			base.agregarVehiculo(unAutoBomba);
		}
		public void agregarHerramienta(Manguera manguera)
		{
			base.agregarHerramienta(manguera);
		}
		
	}
	
	public class Hospital:Base, ICuartel
	{
		static Hospital hospital=null;
		
		Hospital(){}
		
		public static Hospital getInstanciaHospital()
		{
			if(hospital==null)
			{
				hospital=new Hospital();
			}
			
			return hospital;
		}
		
	}
	
	public class Comisaria:Base, ICuartel
	{
		static Comisaria comisaria=null;
		
		Comisaria(){}
		
		public static Comisaria getInstanciaComisaria()
		{
			if(comisaria==null)
			{
				comisaria = new Comisaria();
			}
			
			return comisaria;
		}
		
	}
	
	public class CentralElectrica:Base, ICuartel
	{
		static CentralElectrica central=null;
		
		CentralElectrica(){}
		
		public static CentralElectrica getInstanciaCentralElectrica()
		{
			if(central==null)
			{
				central=new CentralElectrica();
			}
			
			return central;
		}
	}
	
	public class TallerMecanico:Base, ICuartel
	{
		static TallerMecanico taller=null;
		
		TallerMecanico(){}
		
		public static TallerMecanico getInstanceTaller()
		{
			if(taller==null)
			{
				taller=new TallerMecanico();
			}
			
			return taller;
		}
	}
}