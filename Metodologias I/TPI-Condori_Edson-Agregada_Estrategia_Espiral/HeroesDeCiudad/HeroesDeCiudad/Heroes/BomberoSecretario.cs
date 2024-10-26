/*
 * Created by SharpDevelop.
 * User: Alumnos-UNAJ
 * Date: 06/11/2019
 * Time: 20:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using HeroesDeCiudad.Patrones;

namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of BomberoSecretario.
	/// </summary>
	public class BomberoSecretario
	{
		Bombero bombero{get;set;}
		public BomberoSecretario(Bombero bombero)
		{
			this.bombero = bombero;
		}
				
		public void atenderDenuncias(IDenuncias denuncias)
		{
			IIteradorDeDenuncias iterador = denuncias.crearIterador();
			
			while(!iterador.fin())
			{
				iterador.actual().atender(this.bombero);
				iterador.siguiente();
			}
			
		}
	}
}
