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

            
            Console.WriteLine("Imprimir Matrix // antes");
           
           for(var i=0;i<sectores.Length;i++)
           {
           	for(var j=0;j<sectores.Length;j++)
           	{
           		Console.Write("-[{0}{1}]-->{2}",i,j,sectores[i][j].GetPorcentajeDeAfectacion());
           	}
           	Console.WriteLine();
           }
           
           recorrerEspiral(sectores, caudal, 0, 0, 0, n-1);
            
           
           
           Console.WriteLine("\nImprimir Matrix // despues");
           
           for(var i=0;i<sectores.Length;i++)
           {
           	for(var j=0;j<sectores.Length;j++)
           	{
           		Console.Write("-[{0}{1}]->{2}",i,j,sectores[i][j].GetPorcentajeDeAfectacion());
           	}
           	Console.WriteLine("\n");
           }
           
           
        }
        //HACK recorrer en espiral 
        void recorrerEspiral(ISector[][]sectores,int caudal,int fOrigen,int cOrigen,int fDestino,int cDestino)
        {
        	Console.WriteLine("ESPIRAL {0}",sectores.Length);
            
            if (fOrigen==fDestino&&cOrigen<cDestino)
            {
                Console.WriteLine("TEST-Derecha");
                derecha(sectores,caudal,fOrigen,fOrigen,fOrigen,cDestino);
                Console.WriteLine("TEST-Derecha");
                recorrerEspiral(sectores,caudal,fOrigen+1,cDestino,cDestino,cDestino);
            }
            if (fOrigen<fDestino&&cOrigen==cDestino)
            {
                Console.WriteLine("TEST-Abajo");
                abajo(sectores, caudal, fOrigen, cOrigen, cOrigen, cOrigen);
                Console.WriteLine("TEST-Abajo");
                recorrerEspiral(sectores,caudal,fDestino,cOrigen-1,fDestino,fOrigen-1);
            }
            if (fOrigen==fDestino&&cOrigen>cDestino)
            {
            	//cOrigen-1 = fOrigen = fDestino
            	//lo pase como parametro en la condicion anterior para que se cumpla
                Console.WriteLine("TEST-Izquierda");
                izquierda(sectores, caudal, fOrigen, cOrigen, fOrigen, cDestino);
                Console.WriteLine("TEST-Izquierda");
                recorrerEspiral(sectores,caudal,cOrigen,cDestino,cDestino+1,cDestino);
            }
            if (cOrigen==cDestino&&fOrigen>fDestino)
            {
                Console.WriteLine("TEST-Arriba");
                arriba(sectores, caudal, fOrigen, cOrigen, fDestino, cDestino);
                Console.WriteLine("TEST-Arriba");
                recorrerEspiral(sectores,caudal,fDestino,fDestino,fDestino,fOrigen);
            }
            
            if(fDestino==fOrigen&&cOrigen==cDestino)
            {
            	centro(sectores,caudal,fDestino,cDestino);
            }
            
        }
        
        void centro(ISector[][] sectores,int caudal,int fila, int columna)
        {
        	limpiar(sectores,caudal,fila,columna);
        	
            	if(sectores.Length%2==0)
            	{
            		limpiar(sectores,caudal,fila,columna-1);
            	}
            	else
            	{
            		limpiar(sectores,caudal,fila,(columna+1));
            	}
        }
        
        void limpiar(ISector[][] sectores,int caudal,int fila, int columna)//no se me ocurrio antes :/
        {
        while (sectores[fila][columna].GetPorcentajeDeAfectacion() > 0)
                {   
            		Console.Write("{0}%",sectores[fila][columna].GetPorcentajeDeAfectacion());
            		sectores[fila][columna].mojar(caudal);
                    if (sectores[fila][columna].GetPorcentajeDeAfectacion() < 0)
                    {
                    	sectores[fila][columna].SetPorcentajeDeAfectacion(0);
                    }
                }
        Console.Write("{0}%",sectores[fila][columna].GetPorcentajeDeAfectacion());
        }
        
        void derecha(ISector[][]sectores,int caudal,int fOrigen, int cOrigen, int fDestino, int cDestino)
        {
            for (int i=cOrigen;i<=cDestino;i++)
            {
            	Console.WriteLine("sector {0}{1} :{2}%",fOrigen,i,sectores[fOrigen][i].GetPorcentajeDeAfectacion());
                while (sectores[fOrigen][i].GetPorcentajeDeAfectacion() > 0)
                {   
                	Console.Write("{0}%",sectores[fOrigen][i].GetPorcentajeDeAfectacion());
                	sectores[fOrigen][i].mojar(caudal);
                	if (sectores[fOrigen][i].GetPorcentajeDeAfectacion() < 0)
                	{
                   	sectores[fOrigen][i].SetPorcentajeDeAfectacion(0);
                	}
                }
                Console.WriteLine("{0}%",sectores[fOrigen][i].GetPorcentajeDeAfectacion());
            }
            
        }
        
        void abajo(ISector[][] sectores, int caudal, int fOrigen, int cOrigen, int fDestino, int cDestino)
        {
            for (int i = fOrigen; i <= fDestino; i++)
            {
            	Console.WriteLine("sector {0}{1} :{2}%", i, cOrigen, sectores[i][cOrigen].GetPorcentajeDeAfectacion());
                while (sectores[i][cOrigen].GetPorcentajeDeAfectacion() > 0)
                {
                	Console.Write("{0}%", sectores[i][cOrigen].GetPorcentajeDeAfectacion());
                	sectores[i][cOrigen].mojar(caudal);
                	if (sectores[i][cOrigen].GetPorcentajeDeAfectacion() < 0)
                    {
                		sectores[i][cOrigen].SetPorcentajeDeAfectacion(0);
                    }
                }
                Console.WriteLine("{0}%",sectores[i][cOrigen].GetPorcentajeDeAfectacion());
            }
            
        }
        
        
        void izquierda(ISector[][] sectores, int caudal, int fOrigen, int cOrigen, int fDestino, int cDestino)
        {
            for (int i = cOrigen; i >= cDestino; i--)
            {
            	Console.WriteLine("sector {0}{1} :{2}%",fOrigen,i,sectores[fOrigen][i].GetPorcentajeDeAfectacion());
            	while (sectores[fOrigen][i].GetPorcentajeDeAfectacion() > 0)
                {
            		sectores[fOrigen][i].mojar(caudal);
            		if (sectores[fOrigen][i].GetPorcentajeDeAfectacion() < 0)
                    {
            			sectores[fOrigen][i].SetPorcentajeDeAfectacion(0);
                    }
            		Console.Write("{0}%", sectores[fOrigen][i].GetPorcentajeDeAfectacion());
                }
            }
            
        }
        
        
        void arriba(ISector[][] sectores, int caudal, int fOrigen, int cOrigen, int fDestino, int cDestino)
        {
            for (int i = fOrigen; i >= fDestino; i--)
            {
            	Console.WriteLine("\nsector {0}{1} :{2}%",i,cOrigen,sectores[i][cOrigen].GetPorcentajeDeAfectacion());
            	while (sectores[i][cOrigen].GetPorcentajeDeAfectacion() > 0)
            	{	sectores[i][cOrigen].mojar(caudal);
            		if (sectores[i][cOrigen].GetPorcentajeDeAfectacion() < 0)
                	{
            		sectores[i][cOrigen].SetPorcentajeDeAfectacion(0);
            		}
            		Console.Write("{0}%", sectores[i][cOrigen].GetPorcentajeDeAfectacion());
                }
            }
    	}

	}
}


