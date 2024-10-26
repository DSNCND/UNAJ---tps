/*
 * Created by SharpDevelop.
 */
using System;
using HeroesDeCiudad.Heroes;

namespace HeroesDeCiudad.Patrones
{
	/// <summary>
	/// Description of IFabricaDeHeroes.
	/// </summary>
	public interface IFabricaDeHeroes
	{
		IResponsable crearHeroe();
		IHerramienta crearHerramienta();
		IVehiculo crearVehiculo();
		ICuartel crearCuartel();
	}
	
	public class FabricaDeBomberos:IFabricaDeHeroes
	{
		public IResponsable crearHeroe()
		{
			return new Bombero(null);
		}
		public IHerramienta crearHerramienta()
		{
			return new Manguera();
		}
		public IVehiculo crearVehiculo()
		{
			return new Autobomba();
		}
		public ICuartel crearCuartel()
		{
			return CuartelDeBomberos.getInstanciaCuartel();
		}
	}
	
	public class FabricaDeElectricistas:IFabricaDeHeroes
	{
		public IResponsable crearHeroe()
		{
			return new Electricista(null);
		}
		public IHerramienta crearHerramienta()
		{
			return new Buscapolo();
		}
		public IVehiculo crearVehiculo()
		{
			return new Camioneta();
		}
		public ICuartel crearCuartel()
		{
			return CentralElectrica.getInstanciaCentralElectrica();
		}
	}
	
	public class FabricaDeMecanicos:IFabricaDeHeroes
	{
		public IResponsable crearHeroe()
		{
			return new Mecanico(null);
		}
		public IHerramienta crearHerramienta()
		{
			return new Llave();
		}
		public IVehiculo crearVehiculo()
		{
			return new Camioneta();
		}
		public ICuartel crearCuartel()
		{
			return TallerMecanico.getInstanceTaller();
		}
	}
	
	public class FabricaDeMedicos:IFabricaDeHeroes
	{
		public IResponsable crearHeroe()
		{
			return new Medico(null);
		}
		public IHerramienta crearHerramienta()
		{
			return new Desfibrilador();
		}
		public IVehiculo crearVehiculo()
		{
			return new Ambulancia();
		}
		public ICuartel crearCuartel()
		{
			return Hospital.getInstanciaHospital();
		}
	}
	
	public class FabricaDePolicias:IFabricaDeHeroes
	{
		public IResponsable crearHeroe()
		{
			return new Policia(null);
		}
		public IHerramienta crearHerramienta()
		{
			return new Pistola();
		}
		public IVehiculo crearVehiculo()
		{
			return new Patrullero();
		}
		public ICuartel crearCuartel()
		{
			return Comisaria.getInstanciaComisaria();
		}
	}
}
