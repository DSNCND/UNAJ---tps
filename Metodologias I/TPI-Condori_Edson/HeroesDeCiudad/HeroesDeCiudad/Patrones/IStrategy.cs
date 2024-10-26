using System;
using System.Linq;
using HeroesDeCiudad.Lugares;

namespace HeroesDeCiudad.Patrones
{
    public interface IStrategy
    {
        void ApagarIncendio(ILugar lugar, Calle calle);

    }

    class Secuencial: IStrategy
    { 
        public void ApagarIncendio(ILugar lugar, Calle calle)
        {
            Console.WriteLine("apagando incendio secuencialmente");

            ISector[][] sectores = lugar.getSectores();
            for (int i = 0;  i < sectores.Length; i++)
            {
                for (int j = 0; j < sectores[i].Length; j++)
                {
                Console.WriteLine("sector {0}{1} :" + sectores[i][j].GetPorcentajeDeAfectacion() + "%", i, j);
                    while (!sectores[i][j].EstaApagado())
                    {
                        sectores[i][j].mojar(calle.CaudalAguaXMinuto);
                        if (sectores[i][j].GetPorcentajeDeAfectacion() < 0)
                        { sectores[i][j].SetPorcentajeDeAfectacion(0); }
                    Console.Write("apagando " + sectores[i][j].GetPorcentajeDeAfectacion() + "%");
                    }
                Console.WriteLine("\n¡¡¡¡¡¡¡ El fuego de LUGAR fue extinguido en su totalidad !!!!!!\n apagado secuencialmente ");
                }
            }
        }
    }
    class Escalera : IStrategy
    {
       public void ApagarIncendio(ILugar lugar, Calle calle)
        {
            Console.WriteLine("ApagandoIncendio - estrategiaEscalera");

            ISector[][] sectores = lugar.getSectores();
            for (int i = 0; i<sectores.Length; i++)
            {
                if (i%2==0)
                {
                    for (int j=0;j<sectores[i].Length;j++)
                    {
                        Console.Write("apagando" + sectores[i][j].GetPorcentajeDeAfectacion() + "%");
                        while (!sectores[i][j].EstaApagado())
                        {
                            sectores[i][j].SetPorcentajeDeAfectacion(sectores[i][j].GetPorcentajeDeAfectacion() - (int)calle.CaudalAguaXMinuto);
                            
                            if (sectores[i][j].GetPorcentajeDeAfectacion() < 0)
                            { sectores[i][j].SetPorcentajeDeAfectacion(0); }
                            Console.Write(sectores[i][j].GetPorcentajeDeAfectacion() + "%");
                        }
                        
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int j = sectores[i].Length-1; j>=0 ;j--)
                    {
                        Console.Write("apagando" + sectores[i][j].GetPorcentajeDeAfectacion() + "%");
                        while (!sectores[i][j].EstaApagado()) {
                            sectores[i][j].SetPorcentajeDeAfectacion(sectores[i][j].GetPorcentajeDeAfectacion() - (int)calle.CaudalAguaXMinuto);
                            if (sectores[i][j].GetPorcentajeDeAfectacion() < 0)
                            { sectores[i][j].SetPorcentajeDeAfectacion(0); }
                            Console.Write(sectores[i][j].GetPorcentajeDeAfectacion() + "%");
                        }
                        
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n¡¡¡¡¡¡¡ El fuego de LUGAR fue extinguido en su totalidad !!!!!!\n IncendioApagado - estrategiaEscalera");
        }
    }
    
    class Espiral : IStrategy
    {
        //revisar e implementar metodos de sector /EstaApagado y /mojar
        public void ApagarIncendio(ILugar lugar, Calle calle)
        {
            Console.WriteLine("ApagandoIncendio - estrategiaEspiral");
            int caudal = (int)calle.CaudalAguaXMinuto;
            ISector[][] sectores = lugar.getSectores();

            recorrerEspiral(sectores,caudal);
            Console.WriteLine("IncendioApagado - estrategiaEspiral");
        }

        void recorrerEspiral(ISector[][]sectores,int caudal)
        {
            int n = sectores.Length;

            recorrerEspiral(n-1, sectores, caudal, 0, 0, 0, n - 1);
            
            
        }
        //UNDONE recorrer en espiral 
        void recorrerEspiral(int n,ISector[][]sectores,int caudal,int fOrigen,int cOrigen,int fDestino,int cDestino)
        {
            Console.WriteLine("ESPIRAL");
            
           
            if (fOrigen==fDestino&&cOrigen<cDestino)
            {
                Console.WriteLine("TEST-Derecha");
                derecha(sectores,caudal,fOrigen,cOrigen,fDestino,cDestino);
                Console.WriteLine("TEST-Derecha");
                recorrerEspiral(n,sectores,caudal,fDestino,cDestino,cDestino,n-fOrigen);
            }
            if (fOrigen<fDestino&&cOrigen==cDestino)
            {
                Console.WriteLine("TEST-Abajo");
                abajo(sectores, caudal, fOrigen, cOrigen, fDestino, cDestino);
                Console.WriteLine("TEST-Abajo");
                recorrerEspiral(n,sectores,caudal,fDestino,cDestino,fDestino,n-cOrigen);
            }
            if (fOrigen==fDestino&&cOrigen>cDestino)
            {
                Console.WriteLine("TEST-Izquierda");
                izquierda(sectores, caudal, fOrigen, cOrigen, fDestino, cDestino);
                recorrerEspiral(n,sectores,caudal,fDestino,cDestino,n-fOrigen,cDestino);
            }
            if (cOrigen==cDestino&&fOrigen>fDestino)
            {
                Console.WriteLine("TEST-Arriba");
                arriba(sectores, caudal, fOrigen, cOrigen, fDestino, cDestino);
                recorrerEspiral(n,sectores,caudal,fDestino,cDestino,fDestino,n-fDestino-1);
            }
            
            
            
            if (n/2==fDestino&&(n/2)-1==cDestino&& n % 2 == 0)
            {
            	sectores[fDestino][cDestino].SetPorcentajeDeAfectacion(0);
                    
            }
            
            if ((int)((n/2)+1)==fDestino&&(int)((n/2)+1)==cDestino&& n % 2 != 0)
            {
            	sectores[fDestino][cDestino].SetPorcentajeDeAfectacion(0);
            }
        }
        
        void derecha(ISector[][]sectores,int caudal,int fOrigen, int cOrigen, int fDestino, int cDestino)
        {
            for (int i=cOrigen;i<=cDestino;i++)
            {
                Console.WriteLine("sector {0}{1} :{2}%",fOrigen,i,sectores[fOrigen][i]);
                while (sectores[fOrigen][i].GetPorcentajeDeAfectacion() > 0)
                {   
                	sectores[fOrigen][i].SetPorcentajeDeAfectacion( sectores[fOrigen][i].GetPorcentajeDeAfectacion()- caudal);
                    if (sectores[fOrigen][i].GetPorcentajeDeAfectacion() < 0)
                    {
                    	sectores[fOrigen][i].SetPorcentajeDeAfectacion(0);
                    }
                    Console.Write("{0}%",sectores[fOrigen][i]);
                }
                Console.WriteLine();
            }
            
        }
        
        void abajo(ISector[][] sectores, int caudal, int fOrigen, int cOrigen, int fDestino, int cDestino)
        {
            for (int i = fOrigen; i <= fDestino; i++)
            {
                Console.WriteLine("sector {0}{1} :{2}%", i, cOrigen, sectores[i][cOrigen]);
                while (sectores[cOrigen][i].GetPorcentajeDeAfectacion() > 0)
                {
                	sectores[cOrigen][i].mojar(caudal);
                	if (sectores[i][cOrigen].GetPorcentajeDeAfectacion() < 0)
                    {
                		sectores[i][cOrigen].SetPorcentajeDeAfectacion(0);
                    }
                    Console.Write("{0}%", sectores[i][cOrigen]);
                }
            }
            Console.WriteLine();
        }
        
        
        void izquierda(ISector[][] sectores, int caudal, int fOrigen, int cOrigen, int fDestino, int cDestino)
        {
            for (int i = cOrigen; i >= cDestino; i--)
            {
            	while (sectores[fOrigen][i].GetPorcentajeDeAfectacion() > 0)
                {
            		sectores[fOrigen][i].mojar(caudal);
            		if (sectores[fOrigen][i].GetPorcentajeDeAfectacion() < 0)
                    {
            			sectores[fOrigen][i].SetPorcentajeDeAfectacion(0);
                    }
                }
            }
        }
        
        
        void arriba(ISector[][] sectores, int caudal, int fOrigen, int cOrigen, int fDestino, int cDestino)
        {
            for (int i = cOrigen; i >= cDestino; i--)
            {
            	while (sectores[fOrigen][i].GetPorcentajeDeAfectacion() > 0)
            		sectores[fOrigen][i].mojar(caudal);
            	if (sectores[fOrigen][i].GetPorcentajeDeAfectacion() < 0)
                {
            		sectores[fOrigen][i].SetPorcentajeDeAfectacion(0);
                }
            }
        }

    }

}
