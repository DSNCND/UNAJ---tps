/*
 * Created by SharpDevelop.
 * Date: 05/11/2019
 * Time: 08:26 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using HeroesDeCiudad.Lugares;
using System;

namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of IDenuncia.
	/// </summary>
	
	public interface IDenuncia
	{
		void atender(Manejador unResponsable);
	}
	
	class DenunciaDeIncendio: IDenuncia
	{
		ILugar lugar;
		
		public DenunciaDeIncendio(ILugar lugar)
		{
			this.lugar=lugar;
		}
		
		public void atender(Manejador unBombero)
		{
			unBombero.apagarIncendio(this.lugar);
		}
	}
	
	class DenunciaDeInfarto: IDenuncia
	{
		IInfartable victima;
		
		public DenunciaDeInfarto(IInfartable victima)
		{
			this.victima = victima;
		}
		
		public void atender(Manejador unMedico)
		{
			unMedico.atenderInfarto(this.victima);
		}
	}
	
	class DenunciaDeRobo: IDenuncia
	{
		IPatrullable lugar;
		Random random = new Random();
		//TODO deberia ver si paso los randoms desde los Ilugar y eventulamente desde el main
		
		public DenunciaDeRobo(IPatrullable lugar)
		{
			this.lugar = lugar;
		}
		
		public void atender(Manejador unPolicia)
		{
			unPolicia.patrullarCalles(this.lugar);
		}
			
	}
	
	class DenunciaDeLamparaQuemada: IDenuncia
	{
		IIluminable iluminable;
		public DenunciaDeLamparaQuemada(IIluminable iluminable)
		{
			this.iluminable = iluminable;
		}
		
		public void atender(Manejador unElectricista)
		{
			unElectricista.revisar(this.iluminable);
		}
	}
	
	
	
	
}
