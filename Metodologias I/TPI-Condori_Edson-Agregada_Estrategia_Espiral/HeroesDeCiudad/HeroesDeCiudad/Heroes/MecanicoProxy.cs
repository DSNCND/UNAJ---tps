/*
 * Created by SharpDevelop.
 */
using System;
using HeroesDeCiudad.Patrones;

namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of MecanicoProxy.
	/// </summary>
	public class MecanicoProxy:Manejador
	{
		FabricaDeMecanicos mecanicos = null;
		public MecanicoProxy(Manejador manejador):base(manejador)
		{
			mecanicos=new FabricaDeMecanicos();
		}
		
		public override void arreglarMotor(IVehiculo vehiculo)
		{
			TallerMecanico tallerMecanico = (TallerMecanico)mecanicos.crearCuartel();
			tallerMecanico.agregarPersonal((Mecanico)mecanicos.crearHeroe());
			tallerMecanico.agregarHerramienta(mecanicos.crearHerramienta());
			tallerMecanico.agregarVehiculo(mecanicos.crearVehiculo());
			
			Mecanico mecanico = (Mecanico)tallerMecanico.getPersonal();
			mecanico.arreglarMotor((Motorizado)vehiculo);
			tallerMecanico.devolverPersonal(mecanico);
		}
	}
}
