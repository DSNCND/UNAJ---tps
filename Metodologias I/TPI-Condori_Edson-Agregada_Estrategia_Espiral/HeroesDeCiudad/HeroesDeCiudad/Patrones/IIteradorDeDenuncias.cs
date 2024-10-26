/*
 * Created by SharpDevelop.
 * Date: 06/11/2019
 * Time: 02:22 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using HeroesDeCiudad.Heroes;

namespace HeroesDeCiudad.Patrones
{
	/// <summary>
	/// Description of IIteradorDeDenuncias.
	/// </summary>
	public interface IIteradorDeDenuncias
	{
		void primero();
		IDenuncia actual();
		void siguiente();
		bool fin();
	}
	
	public class IteradorDenunciasXTablero:IIteradorDeDenuncias
	{
		List<IDenuncia> denuncias=null;
		int indice = 0;
		public IteradorDenunciasXTablero(List<IDenuncia> denuncias)
		{
			this.denuncias=denuncias;
		}
		public void primero()
		{
			indice = 0;
		}
		
		public IDenuncia actual()
		{
			return denuncias[indice];
		}
		
		public void siguiente()
		{
			indice++;
		}
		
		public bool fin()
		{
			return indice>=denuncias.Count;
		}
		
	}
	
	public class IteradorDeDenunciasXWhatsApp:IIteradorDeDenuncias
	{
		MensajeDeWhatsApp lista;
		MensajeDeWhatsApp back;
		
		public IteradorDeDenunciasXWhatsApp(MensajeDeWhatsApp lista)
		{
			this.lista=lista;
			back=lista;
		}	
		
		public void primero()
		{
			lista=back;
		}
		
		public IDenuncia actual()
		{
			return lista.getDenuncia();
		}
		
		public void siguiente()
		{
			lista = lista.getMensajeAnterior();
		}
		
		public bool fin()
		{
			return lista.getMensajeAnterior()==null;
		}
	}
	
	public class IteradorDenunciasXMostrador:IIteradorDeDenuncias
	{
		DenunciasPorMostrador denuncia;
		int cont = 0;
		public IteradorDenunciasXMostrador(DenunciasPorMostrador denuncia)
		{
			this.denuncia=denuncia;
			cont++;
		}
		
			
		public void primero()
		{
			cont=1;
		}
		
		public IDenuncia actual()
		{
			return denuncia.getDenuncia();
		}
		
		public void siguiente()
		{
			cont++;
		}
		
		public bool fin()
		{
			return cont>=2;
		}
	}
	
	
}
