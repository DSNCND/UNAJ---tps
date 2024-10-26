/*
 * Created by SharpDevelop.
 * Date: 11/11/2019
 * Time: 01:42 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using HeroesDeCiudad.Patrones;


namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of Operador911.
	/// </summary>
	public class Operador911
	{
		Manejador responsable;
		
		public Operador911(IResponsable responsable)
		{
			this.responsable = (Manejador)responsable;
		}
		
		public void atenderDenuncias(IDenuncias denuncias)
		{
			IIteradorDeDenuncias iterador = denuncias.crearIterador();
			while(!iterador.fin())
			{
				iterador.actual().atender(this.responsable);
				iterador.siguiente();
				
			}
		}
	}
}
