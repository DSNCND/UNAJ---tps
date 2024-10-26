/*
 * Created by SharpDevelop.
 * Date: 23/10/2019
 * Time: 08:24 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using HeroesDeCiudad.Lugares;

namespace HeroesDeCiudad.Patrones

	
{
	/// <summary>
	/// patron Builder .
	/// </summary>
	public abstract class BuilderDeSector
	{
		
		public virtual ISector ConstruirSector(int caudalDeLluvia, int temperatura, int velocidadDeViento, Random random)
		{
			
			return FactoryMethodSectores.crearSectorSimple();
		}
		
		
		protected virtual ISector decorarSector(ISector sector, int caudalLluvia, int temperatura, int velocidadViento, Random random)
        
        {
			
            const double probabilidad_de_decorar = 0.2;
            Console.WriteLine("Decorar?");
            
            if (random.NextDouble() < probabilidad_de_decorar)
            {
            	Console.WriteLine("Decorado pasto seco");
            	sector = FactoryMethodSectores.decorarSector(1,sector,0);
            }
            	
            if (random.NextDouble() < probabilidad_de_decorar)
            { 
            	Console.WriteLine("Decorado arboles grandes");
            	sector =  FactoryMethodSectores.decorarSector(2,sector,0); 
            }
            
            if (random.NextDouble() < probabilidad_de_decorar)
            {
            	Console.WriteLine("Decorado gente asustada") ;
           		sector = FactoryMethodSectores.decorarSector(5,sector,0);
            }
            
            if (temperatura > 30) 
            {
            	Console.WriteLine("hace calor");
            	sector = FactoryMethodSectores.decorarSector(3,sector,temperatura);
            }
            
            if (velocidadViento > 80)
            {
            	Console.WriteLine("viento");
            	sector = FactoryMethodSectores.decorarSector(4,sector,velocidadViento);
            }
            
            if (caudalLluvia > 0)
            {
            	Console.WriteLine("dia lluvioso");
            	sector = FactoryMethodSectores.decorarSector(6,sector,caudalLluvia);
            }

            Console.WriteLine("TEST----DECORAR----Mixto");      
            
            return sector;
        }
	}
	
	public class ConstructorSimple:BuilderDeSector
	{
		public override ISector ConstruirSector(int caudalDeLluvia, int temperatura, int velocidadDeViento, Random random)
		{
			Console.WriteLine("Sector Simple ---------");
			//podria haber dejado el constructor de la clase padre
			return decorarSector();
		}
		
		protected ISector decorarSector()
		{
			return FactoryMethodSectores.crearSectorSimple();
		}
	}
	
	public class ConstructorFavorable:BuilderDeSector
	{
		
		public override ISector ConstruirSector(int caudalDeLluvia, int temperatura, int velocidadDeViento,Random random)
		{
			
			return decorarSector(FactoryMethodSectores.crearSectorSimple(),caudalDeLluvia);
		}
		
		protected ISector decorarSector(ISector sector, int caudalLluvia)
        {
            
            sector = FactoryMethodSectores.decorarSector(6,sector,caudalLluvia);

            Console.WriteLine("DECORAR---Favorable--lluvia");  
            
            return sector;
        }

	}
	
	public class ConstructorDesfavorable:BuilderDeSector
	{
		public override ISector ConstruirSector( int caudalDeLluvia, int temperatura, int velocidadDeViento, Random random)
		{
			ISector sector = FactoryMethodSectores.crearSectorSimple();
			sector = decorarSector(sector,temperatura,velocidadDeViento,random);
			return sector;
		}
		
		protected ISector decorarSector(ISector sector,  int temperatura, int velocidadViento, Random random)
        {
			
            const double probabilidad_de_decorar = 0.2;
            Console.WriteLine("Decorar?");
            
            if (random.NextDouble() < probabilidad_de_decorar)
            {
            	Console.WriteLine("Decorado pasto seco");
            	sector = FactoryMethodSectores.decorarSector(1,sector,0);
            }
            	
            if (random.NextDouble() < probabilidad_de_decorar)
            { 
            	Console.WriteLine("Decorado arboles grandes");
            	sector =  FactoryMethodSectores.decorarSector(2,sector,0); 
            }
            
            if (random.NextDouble() < probabilidad_de_decorar)
            {
            	Console.WriteLine("Decorado gente asustada") ;
           		sector = FactoryMethodSectores.decorarSector(5,sector,0);
            }
            
            if (temperatura > 30) 
            {
            	Console.WriteLine("hace calor");
            	sector = FactoryMethodSectores.decorarSector(3,sector,temperatura);
            }
            
            if (velocidadViento > 80)
            {
            	Console.WriteLine("viento");
            	sector = FactoryMethodSectores.decorarSector(4,sector,velocidadViento);
            }
            
            Console.WriteLine("DECORAR----Desfavorable");      
            
            return sector;
        }

	}
	
	public class ConstructorMixto:BuilderDeSector
	{
		public override ISector ConstruirSector( int caudalDeLluvia, int temperatura, int velocidadDeViento, Random random)
		{
			ISector sector = FactoryMethodSectores.crearSectorSimple();
			sector = decorarSector(sector,caudalDeLluvia,temperatura,velocidadDeViento,random);
			Console.WriteLine("DECORAR----Mixtos");  
			return sector;
		}
		
		

	}
	
	//HACK Director
	public class directorDeSector
	{
		BuilderDeSector builder = new ConstructorSimple();
		
		public directorDeSector()
			{
			
            }
	 
		
		public directorDeSector(BuilderDeSector builder)
			{
               this.builder=builder;
            }
		
		public void SetBuilder(BuilderDeSector builder)
		{
			this.builder=builder;
		}
	 
		public ISector[][] crearSectoresAfectados(int caudalDeLluvia, int temperatura, int velocidadDeViento, double superficie)
        {
            Random random = new Random();
            int valorAfectacion;
            int N = (int)Math.Round(Math.Sqrt(superficie));
            ISector[][] sectoresAfectacion = new ISector[N][];

            for (int i = 0; i < N; i++)
            {
                sectoresAfectacion[i] = new ISector[N];
                for (int j = 0; j < N; j++)
                {
                	valorAfectacion=random.Next(101);
                	sectoresAfectacion[i][j] = builder.ConstruirSector(caudalDeLluvia,temperatura,velocidadDeViento,random);
                	sectoresAfectacion[i][j].SetPorcentajeDeAfectacion(valorAfectacion);
                }
            }
            return sectoresAfectacion;
        }
	}
}
