/*
 * Created by SharpDevelop.
 */
using System;
using HeroesDeCiudad.Lugares;
using HeroesDeCiudad.Patrones;

namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of ElectricistaProxy.
	/// </summary>
	public class ElectricistaProxy:Manejador
	{
		FabricaDeElectricistas fabricaElectricistas=null;
		public ElectricistaProxy(Manejador manejador):base(manejador)
		{
			fabricaElectricistas=new FabricaDeElectricistas();
		}
		
		public override void revisar(IIluminable iluminable)
		{
			Electricista electricista = (Electricista)fabricaElectricistas.crearHeroe();
			electricista.setHerramienta(fabricaElectricistas.crearHerramienta());
			electricista.setVehiculo(fabricaElectricistas.crearVehiculo());
			
			electricista.revisar(iluminable);
		}
	}
}
