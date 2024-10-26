using System;
using HeroesDeCiudad.Patrones;

namespace HeroesDeCiudad.Lugares
{
    public class Sector:ISector
    {
        double porcentajeDeAfectacion = 0;

        public Sector()
        {
        }
        public Sector(double afectacion)
        {
            this.porcentajeDeAfectacion = afectacion;
        }

        public double GetPorcentajeDeAfectacion()
        {
            return porcentajeDeAfectacion;
        }
        public void SetPorcentajeDeAfectacion(double porcentaje)
        {
            this.porcentajeDeAfectacion = porcentaje;
        }

        public void mojar(double agua)
        {
            porcentajeDeAfectacion -= agua;
        }
        public bool EstaApagado()
        {
            if (porcentajeDeAfectacion == 0)
            {
                return true;
            }

            return false;
        }
        
        private static ISector decorarSector(ISector sector, int caudalLluvia, int temperatura, int velocidadViento, Random random)
        {
            
            double probabilidad_de_decorar = 0.2;
            double rand=random.NextDouble();
            Console.WriteLine("Decorar? "+rand+"<0.2");
            if (rand < probabilidad_de_decorar)
            {
                Console.WriteLine("Decorado pasto seco");
                //Console.ReadKey();
                sector = new PastoSeco(sector);
            }
            rand = random.NextDouble();
            Console.WriteLine("Decorar? " + rand + "<0.2");
            if (random.NextDouble() < probabilidad_de_decorar){ Console.WriteLine("Decorado arboles grandes");sector =  FactoryMethodSectores.decorarSector(2,sector,0); }
            if (random.NextDouble() < probabilidad_de_decorar){ Console.WriteLine("Decorado gente asustada") ; sector = FactoryMethodSectores.decorarSector(5,sector,0);  }
            if (temperatura > 30) {Console.WriteLine("hace calor");sector = FactoryMethodSectores.decorarSector(3,sector,temperatura);}
            if (velocidadViento > 80){ Console.WriteLine("viento");sector = FactoryMethodSectores.decorarSector(4,sector,velocidadViento);}
            if (caudalLluvia > 0){ Console.WriteLine("dia lluvioso");sector = FactoryMethodSectores.decorarSector(6,sector,caudalLluvia);}

            return sector;
        }

        public static ISector crearSector(int caudalLluvia, int temperatura, int velocidadViento, Random random)
        {
            int caudal = random.Next(100);
            ISector sector = new Sector(caudal);
            return decorarSector(sector, caudalLluvia, temperatura, velocidadViento,random);
        }



    }
}
