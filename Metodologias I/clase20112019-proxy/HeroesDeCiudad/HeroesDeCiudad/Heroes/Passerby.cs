/*
 * Clase que representa un transeúnte extranjero.
 * 
 * Se debe utilizar esta clase para la práctica del patrón Adapter creando un adaptador 
 * para adaptarla a la interface IInfartable
 * 
 * User: Waldo
 * Date: 09/09/2019
 * Time: 15:33
 * 
 */
using System;

namespace HeroesDeCiudad
{

	public class Passerby
	{
		static Random random = new Random();
		
		private double probConscius, probBrathing, probHeartRate;
		
		public Passerby(double pc, double pb, double phr)
		{
			probConscius = pc; 
			probBrathing = pb;
			probHeartRate = phr;
		}
		
		public bool isConscious(){
			return random.NextDouble() < probConscius;
		}
		
		public bool isBreathing(){
			return random.NextDouble() < probBrathing;
		}
		
		public bool haveHeartRate(){
			return random.NextDouble() < probHeartRate;
		}
	}
}
