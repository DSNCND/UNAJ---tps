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
	public class BomberoProxy:Manejador
	{
		FabricaDeBomberos fabricaDeBomberos=null;
		Bombero bombero=null;
		
		public BomberoProxy(Manejador manejador):base(manejador)
		{
			fabricaDeBomberos=new FabricaDeBomberos();
		}
		public Bombero getBombero()
		{
			return bombero;
		}
		
		
		public override void apagarIncendio(ILugar lugar)
		{
			bombero = (Bombero)fabricaDeBomberos.crearHeroe();
			bombero.setHerramienta(fabricaDeBomberos.crearHerramienta());
			bombero.setVehiculo(fabricaDeBomberos.crearVehiculo());

			Console.WriteLine("\n<<BomberoProxy - creando bombero>>");
			a:
			Console.WriteLine("Seleccione estrategia: ");
			Console.WriteLine("\t 1: Secuencial");
			Console.WriteLine("\t 2: Escalera");
			Console.WriteLine("\t 3: Spiral");
			
			
			try{
			int opcion = int.Parse(Console.ReadLine());
			Console.WriteLine(opcion);
		
			while(opcion<1|opcion>3)
			{
				Console.WriteLine("Seleccione estrategia: ");
				Console.WriteLine("\t 1: Secuencial");
				Console.WriteLine("\t 2: Escalera");
				Console.WriteLine("\t 3: Spiral");
				opcion = int.Parse(Console.ReadLine());
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
			catch(Exception e)
			{
				Console.WriteLine(e.Message+"\ntipo: "+e.GetType().Name+"\n");
				goto a;
			}
		}
	}
}
