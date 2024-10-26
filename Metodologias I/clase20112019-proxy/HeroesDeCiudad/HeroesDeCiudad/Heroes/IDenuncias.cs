/*
 * Created by SharpDevelop.
 * Date: 05/11/2019
 * Time: 11:01 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using HeroesDeCiudad.Patrones;
using HeroesDeCiudad.Lugares;

namespace HeroesDeCiudad.Heroes
{
	/// <summary>
	/// Description of IDenuncias.
	/// </summary>
	public interface IDenuncias
	{
		IIteradorDeDenuncias crearIterador();
		//void agregarDenuncia(ILugar lugar);
		void agregarDenuncia(IDenuncia denuncia);
	}
	
	public class DenunciasPorTablero:IObservador,IDenuncias
	{
		List<IDenuncia> denuncias;
		
		public DenunciasPorTablero()
		{
			denuncias = new List<IDenuncia>();
		}
		
		public void alarmaDeIncendio(ILugar lugar)
		{
			lugar.agregarObservador(this);
		}
		
		public void agregarDenuncia(IDenuncia denuncia)
		{
			denuncias.Add(denuncia);
		}
		
		public IIteradorDeDenuncias crearIterador()
		{
			return new IteradorDenunciasXTablero(denuncias);
		}
	}
	
	public class MensajeDeWhatsApp
	{
		MensajeDeWhatsApp mensajeAnterior = null;
		IDenuncia denuncia = null;
		
		public MensajeDeWhatsApp(IDenuncia denuncia)
		{
			this.denuncia = denuncia;
		}
		public MensajeDeWhatsApp(IDenuncia denuncia, MensajeDeWhatsApp anteriorWApp)
		{
			this.denuncia = denuncia;
			this.mensajeAnterior = anteriorWApp;
		}
		
		public MensajeDeWhatsApp getMensajeAnterior()
		{
			return mensajeAnterior;
		}
		public IDenuncia getDenuncia()
		{
			return denuncia;
		}
		
		
	}
	public class DenunciasPorWhatsApp:IDenuncias
	{
		MensajeDeWhatsApp lista = null;
		
		public DenunciasPorWhatsApp(MensajeDeWhatsApp lista)
		{
			this.lista = lista;
		}
		
		public MensajeDeWhatsApp getLista()
		{
			return this.lista;
		}
		
		public void agregarDenuncia(IDenuncia denuncia)
		{
			lista = new MensajeDeWhatsApp(denuncia, this.lista);
		}
		
		public IIteradorDeDenuncias crearIterador()
		{
			return new IteradorDeDenunciasXWhatsApp(lista);
		}
		
		
	}
	
	public class DenunciasPorMostrador:IDenuncias
	{
		IDenuncia denuncia;
		
		public DenunciasPorMostrador(IDenuncia denuncia)
		{this.denuncia = denuncia;}
		

		public IIteradorDeDenuncias crearIterador()
		{
			return new IteradorDenunciasXMostrador(this);
		}
		public void agregarDenuncia(IDenuncia denuncia)
		{
			this.denuncia=denuncia;
		}
		
		public IDenuncia getDenuncia(){return denuncia;}
	}
	
}
