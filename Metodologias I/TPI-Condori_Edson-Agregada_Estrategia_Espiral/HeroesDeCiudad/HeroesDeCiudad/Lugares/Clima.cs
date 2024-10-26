/*
 * Created by SharpDevelop.
 * Date: 08/11/2019
 * Time: 10:27 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace HeroesDeCiudad.Lugares
{
	/// <summary>
	/// Description of Clima.
	/// </summary>
	public class Clima
	{
		public int caudalDeLluvia{get;set;}
		public int temperatura{get;set;}
		public int velocidadDelViento{get;set;}
		
		public Clima(int caudalDeLluvia,int temperatura,int velocidadDelViento)
		{
			this.caudalDeLluvia=caudalDeLluvia;
			this.temperatura=temperatura;
			this.velocidadDelViento=velocidadDelViento;
		}
	}
}
