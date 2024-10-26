/*
 * Created by SharpDevelop.
 */
using System;
using HeroesDeCiudad.Patrones;
using HeroesDeCiudad.Lugares;


namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of BomberoProxy.
	/// </summary>
	public class BomberoProxy:Manejador, IResponsable
	{
		FabricaDeBomberos fabricaDeBomberos=null;
		Bombero bombero=null;
		
		public BomberoProxy(Manejador manejador):base(manejador)
		{
			fabricaDeBomberos=new FabricaDeBomberos();
		}
		
		/*
		public override IHerramienta getHerramienta()
		{
			if(bombero.getHerramienta==null)
			{
				bombero.setHerramienta(fabricaDeBomberos.crearHerramienta());
			}
			
			return bombero.getHerramienta();
		}*/
		
		public override void apagarIncendio(ILugar lugar)
		{
			
			bombero = (Bombero)fabricaDeBomberos.crearHeroe();
			bombero.setHerramienta(fabricaDeBomberos.crearHerramienta());
			bombero.setVehiculo(fabricaDeBomberos.crearVehiculo());
			
			Console.WriteLine("Seleccione estrategia: ");
			Console.WriteLine("\t 1: Secuencial");
			Console.WriteLine("\t 2: Escalera");
			Console.WriteLine("\t 3: Spiral");
			
			var opcion = Console.Read();
			while(opcion<1&&opcion>3)
			{
				Console.WriteLine("Seleccione estrategia: ");
				Console.WriteLine("\t 1: Secuencial");
				Console.WriteLine("\t 2: Escalera");
				Console.WriteLine("\t 3: Spiral");
				opcion = Console.Read();
			}
			
			
			switch(opcion)
			{
				case 1: bombero.SetEstrategia(new Secuencial());
				break;
				case 2: bombero.SetEstrategia(new Escalera());
				break;
				case 3: bombero.SetEstrategia(new Espiral());
				break;
			}

			bombero.apagarIncendio(lugar);
			
		}
	}
}
