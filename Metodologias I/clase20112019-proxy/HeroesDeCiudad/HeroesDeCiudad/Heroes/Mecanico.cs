﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesDeCiudad.Heroes
{
	class Mecanico:Manejador
    {
		Llave llave;
		Camioneta camioneta;
		
		public Mecanico(Manejador manejador):base(manejador){}
    	
		public Mecanico(Manejador manejador, Llave llave, Camioneta camioneta):base(manejador)
		{
			this.llave = llave;
			this.camioneta = camioneta;
		}
		
        public override IHerramienta getHerramienta()
        {
        	return llave;
        }
        
        public void setHerramienta(Llave llave)
        {
        	this.llave=llave;
        }
		public override void setHerramienta(IHerramienta herramienta)
		{
			this.llave = (Llave)herramienta;
		}
			     
		public override IVehiculo getVehiculo()
		{
			return camioneta;
		}
		
		public void setVehiculo(Camioneta camioneta)
		{
			this.camioneta=camioneta;
		}
		public override void setVehiculo(IVehiculo vehiculo)
		{
			camioneta = (Camioneta)vehiculo;
		}
		
    	
        public override void arreglarMotor(IVehiculo vehiculo)
        {
        	getHerramienta().usar();
            Console.WriteLine("arreglando motor de la/del {0}",vehiculo);
            getHerramienta().guardar();
        }

        public override void remolcarAuto(IVehiculo vehiculo)
        {
        	getVehiculo().conducir();
            Console.WriteLine("remolcando {0}",vehiculo);
            
        }


    }
}
