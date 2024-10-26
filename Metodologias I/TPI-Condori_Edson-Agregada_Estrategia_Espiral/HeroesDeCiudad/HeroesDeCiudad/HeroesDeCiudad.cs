/*
 * Created by SharpDevelop.
 * Date: 22/10/2019
 * Time: 08:47 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using HeroesDeCiudad.Heroes;
using HeroesDeCiudad.Lugares;
using HeroesDeCiudad.Patrones;

namespace HeroesDeCiudad
{
	class HeroesDeCiudad
	{
		public static void Main(string[] args)
		{
			
			Console.Title="HeroesDeCiudad";
			
			//Console.BackgroundColor = ConsoleColor.DarkMagenta;
			//Console.ForegroundColor = ConsoleColor.Green;
			
			//Console.BackgroundColor = ConsoleColor.DarkGray;
			//Console.ForegroundColor = ConsoleColor.DarkCyan;
			//Console.ForegroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.BackgroundColor = ConsoleColor.DarkCyan;
			Console.Clear();
			
			Random random = new Random();
			
           	directorDeSector director = new directorDeSector(new ConstructorSimple());
           	director.SetBuilder(new ConstructorMixto());
           	director.SetBuilder(new ConstructorDesfavorable());
            BomberoProxy bombero = new BomberoProxy(null);
            Calle mitre = new Calle(100, 4, 50);
            Plaza plaza = new Plaza(100, mitre, 3, 3, director);
            bombero.apagarIncendio(plaza);
            
            Console.WriteLine(((Motorizado)(bombero.getBombero().getVehiculo())).getEstado());
            ((Motorizado)(bombero.getBombero().getVehiculo())).setEstado(new Roto(((Motorizado)(bombero.getBombero().getVehiculo()))));
            
            MecanicoProxy mecanico = new MecanicoProxy(null);
            mecanico.arreglarMotor(((Motorizado)(bombero.getBombero().getVehiculo())));
			
            
            ElectricistaProxy electricista = new ElectricistaProxy(null);
            electricista.revisar(mitre);
            electricista.revisar(plaza);
            
            //UNDONE proxys medico y policia 
            
            
            /*
            dynamic manzana = crearManzana();
            manzana.AgregarComponentes(plaza);
            electricista.revisar(manzana);
            electricista.revisar(crearBarrio(9,2));

            CompositeDeCiudad ciudad = new CompositeDeCiudad();
            ciudad.AgregarComponentes(crearBarrio(9, 2));
            ciudad.AgregarComponentes(crearBarrio(7, 1));
            ciudad.AgregarComponentes(crearBarrio(5, 2));
            ciudad.AgregarComponentes(crearBarrio(6, 0));
            Console.WriteLine("///////ciudad");
            
            electricista.revisar(ciudad);
			*/


            /*
            ///test policia comand
            testComand(random);

            ///test medico RCP template method
            TestRCP(random);
            */
           
           
           
           /*
           List<ILugar> lugares = TESTBuilder();
           foreach(ILugar lugar in lugares)
           	{
           	Console.Clear();
           	//Console.ReadKey();
           	Console.WriteLine("ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ");
           	
           	lugar.agregarObservador(bombero);
           	lugar.chispa(11,33,90);
           	Console.ReadKey();
           	}
           
           */
           

          
           //TestIteratorDeDenuncias(random);
           
           //TestFabricas();
	      
	       
	       formato();
           fTab();
           pausa();

        }//HACK fin main
		
		
		static void fTab() { Console.Write("\t"); }
        static void formato()
        {
            Console.Write("\n\n\n\n");
        }
        static void pausa()
        {
            Console.WriteLine("Presione una tecla para continuar.");
            Console.Write("\t");
            Console.ReadKey();
        }

        ////HACK COMPOSITE
        
        static CompositeDeCiudad crearManzana()
        {
            Console.WriteLine("////manzana");

            CompositeDeCiudad manzana = new CompositeDeCiudad();

            Calle calle01 = new Calle();
            Calle calle02 = new Calle();
            Calle calle03 = new Calle();
            Calle calle04 = new Calle();

            Esquina esquina12 = new Esquina(4);
            Esquina esquina23 = new Esquina(4);
            Esquina esquina34 = new Esquina(4);
            Esquina esquina41 = new Esquina(4);

            manzana.AgregarComponentes(calle01);
            manzana.AgregarComponentes(calle02);
            manzana.AgregarComponentes(calle03);
            manzana.AgregarComponentes(calle04);

            manzana.AgregarComponentes(esquina12);
            manzana.AgregarComponentes(esquina23);
            manzana.AgregarComponentes(esquina34);
            manzana.AgregarComponentes(esquina41);

            return manzana;
        }

        static CompositeDeCiudad crearBarrio(int cantidadManzanas, int cantPlazas)
        {
            Console.WriteLine("//////Barrio");
            CompositeDeCiudad barrio = new CompositeDeCiudad();
            int aux = cantPlazas;
            for (int i=0;i<cantidadManzanas;i++)
            {
                CompositeDeCiudad manzana = crearManzana();
                if (aux!=0)
                {
                	manzana.AgregarComponentes(new Plaza(100,new Calle(100,4,5),8,11,new directorDeSector(new ConstructorSimple())));
                    aux--;
                }
                barrio.AgregarComponentes(manzana);
            }

            return barrio;
        }

        static void testComand(Random random)
        {
            
            Policia policia = new Policia(null);
            policia.setComandoPop(new armarRecorridoAPatrullar());
            policia.setComandoPush(new VozDeAlto());
            
            for(int i=0; i<15; i++)
            {
                int lugar = random.Next(1, 4);
                IPatrullable lugarPatrullable = new Esquina();

                if (lugar == 1)
                {
                    Console.WriteLine("Patrullar esquina");
                    lugarPatrullable = new Esquina();
                }
                if (lugar == 2)
                {
                    Console.WriteLine("Patrullar casa");
                    lugarPatrullable = new Casa(new directorDeSector(new ConstructorMixto()));
                }
                if (lugar == 3)
                {
                    Console.WriteLine("Patrullar plaza");
                    lugarPatrullable = new Plaza(new directorDeSector(new ConstructorSimple()));
                }
                policia.setLugaresAPatrullar(lugarPatrullable);
            }
            List<IPatrullable> lista = policia.getLugaresAPatrullar();
            foreach (IPatrullable lugar in lista)
            {
                if ( lista.IndexOf(lugar) < 5)
                {
                    policia.setComandoPop(new VozDeAlto());
                
                }
                if (lista.IndexOf(lugar) >= 5 && lista.IndexOf(lugar) < 10)
                {
                    policia.setComandoPop(new Perseguir());
                }
                if (lista.IndexOf(lugar) >= 10)
                {
                    policia.setComandoPop(new PedirRefuerzos());
                }
                Console.WriteLine("lugar: {0}",lista.IndexOf(lugar));
                policia.patrullarCalles(lugar);
            }

        }

        //HACK TEST template method - Medico - RCP
        static void TestRCP(Random random)
        {
            TemplateRCP rcp = new RCP2();
            Medico medico = new Medico(null);
            medico.setRCP(rcp);
            Transeunte transeunte = new Transeunte(0.3,0.8,0.3,random);
            medico.atenderInfarto(transeunte);
            medico.setRCP(new RCP1());
            medico.atenderInfarto(transeunte);
            Passerby passerby = new Passerby(0.3,0.8,0.3);
            Adapter adapter = new Adapter(passerby);
            medico.atenderInfarto(adapter);
        }
        //HACK TEST Builder - director
        static List<ILugar> TESTBuilder()
        {
        	List<ILugar> lugares = new List<ILugar>();
        	
        	directorDeSector director = new directorDeSector();
        	directorDeSector director2 = new directorDeSector();
        	directorDeSector director3 = new directorDeSector();
        	directorDeSector director4 = new directorDeSector();
        	
        	BuilderDeSector simples = new ConstructorSimple();
        	BuilderDeSector favorables = new ConstructorFavorable();
        	BuilderDeSector desFavorables = new ConstructorDesfavorable();
        	BuilderDeSector mixtos = new ConstructorMixto();
        	
        	Calle calle = new Calle(100,10,20);
        	
        	Casa casa1 = new Casa(01,100,4,calle,director);
        	Casa casa2 = new Casa(02,120,3,calle,director2);
        	Plaza plaza1 = new Plaza(800,calle,22,33,director3);
        	Plaza plaza2 = new Plaza(1300,calle,33,35,director4);
        	
        	casa1.director.SetBuilder(simples);
        	casa2.director.SetBuilder(favorables);
        	plaza1.director.SetBuilder(desFavorables);
        	plaza2.director.SetBuilder(mixtos);
        	
        	lugares.Add(casa1);
        	lugares.Add(casa2);
        	lugares.Add(plaza1);
        	lugares.Add(plaza2);
        	
        	return lugares;
        	
        }
        
        //HACK 11 - TEST Iterator - Denuncias 
        //HACK 12 - Chain Of Responsability
        
        static void TestIteratorDeDenuncias(Random random)
        {
        	/*
        	 Testing
			Implemente una función main en la clase HeroesDeCiudad para que instancie un BomberoSecretario,
			un Bombero (con cualquier estrategia) y diez ILugar cualquiera (casa o plaza), llamémoslos: A, B, C, D, E, F, G, H, I y J.
			*/
        	BomberoSecretario bomberoS = new BomberoSecretario(new Bombero(null));
        	List<ILugar> ILugares = TESTBuilder();
        	List<ILugar> lugares = TESTBuilder();
        	
        	for(var i =0;i<2;i++)
        	foreach(ILugar lugar in lugares)
        	{
        		ILugares.Add(lugar);
        	}
        	
        	ILugar A = ILugares[0];
        	ILugar B = ILugares[1];
        	ILugar C = ILugares[2];
        	ILugar D = ILugares[3];
        	ILugar E = ILugares[4];
        	ILugar F = ILugares[5];
        	ILugar G = ILugares[6];
        	ILugar H = ILugares[7];
        	ILugar I = ILugares[8];
        	ILugar J = ILugares[9];
        	
        	/*
        	Instancie una DenunciasPorTablero y hágala observadora de los lugares A, B, C, D, E y F.
			Instancie una DenunciasPorWhatsapp y agréguele los lugares G, H e I.
			Instancie una DenunciasPorMostrador con el lugar J.
			*/
        	DenunciasPorTablero denunciasXTablero = new DenunciasPorTablero();
        	denunciasXTablero.alarmaDeIncendio(A);
        	denunciasXTablero.alarmaDeIncendio(B);
        	denunciasXTablero.alarmaDeIncendio(C);
        	denunciasXTablero.alarmaDeIncendio(D);
        	denunciasXTablero.alarmaDeIncendio(E);
        	denunciasXTablero.alarmaDeIncendio(F);
      	        	
        	
        	MensajeDeWhatsApp lista = new MensajeDeWhatsApp(new DenunciaDeIncendio(G));
        	DenunciasPorWhatsApp denunciasXWhatsApp = new DenunciasPorWhatsApp(lista);
        	denunciasXWhatsApp.agregarDenuncia(new DenunciaDeIncendio(H));
        	denunciasXWhatsApp.agregarDenuncia(new DenunciaDeIncendio(I));
        	
        	DenunciasPorMostrador denunciaXMostrador = new DenunciasPorMostrador(new DenunciaDeIncendio(J));
        	
        	/*
        	 Invoque al método chispa de los lugares B y F (para que se agreguen denuncias a la lista de DenunciasPorTablero).
			Invoque al método atenderDenuncias del BomberoSecretario con las tres IDenuncias instanciadas.
			Compruebe el correcto funcionamiento del sistema.
        	*/
        	Clima clima = new Clima(80,35,120);
        	
        	B.chispa(clima.caudalDeLluvia,clima.temperatura,clima.velocidadDelViento);
        	F.chispa(30,22,90);
        	bomberoS.atenderDenuncias(denunciasXTablero);
        	bomberoS.atenderDenuncias(denunciasXWhatsApp);
        	bomberoS.atenderDenuncias(denunciaXMostrador);
        	
        	Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        	Console.WriteLine("<<<<<<<<<<<<<<<<<cadena de responsabilidades<<<<<<<<<<");
        	Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        	
        	Manejador responsable = new Medico(new BomberoProxy(null));
			//Manejador responsable = new Medico(new Bombero(null));
        	responsable = new Medico(responsable);
        	((Medico)responsable).setRCP(new RCP2());
        	responsable = new Policia(responsable);
        	//((dynamic)responsable).setComandoPop(new VozDeAlto());
        	((Policia)responsable).setComandoPop(new VozDeAlto());
        	((Policia)responsable).setComandoPush(new Perseguir());
        	responsable = new Electricista(responsable);
        	
        	Operador911 Operador = new Operador911(responsable);
        	denunciasXTablero.agregarDenuncia(new DenunciaDeRobo((Casa)J));
        	Operador.atenderDenuncias(denunciasXTablero);
        	
        	denunciasXWhatsApp.agregarDenuncia(new DenunciaDeInfarto(new Transeunte(3,3,3,random)));
        	denunciasXWhatsApp.agregarDenuncia(new DenunciaDeInfarto(new Adapter(new Passerby(3,3,3))));
        	
        	Operador.atenderDenuncias(denunciasXWhatsApp);
        	
        }
        
        //HACK 13 - Fabrica abstracta
        
        static ICuartel crearHeroe(IFabricaDeHeroes fabrica,int cantidad)
        {
        	ICuartel cuartel = fabrica.crearCuartel();
        	if(cantidad>1)
        	{
        	for(var i=0;i<cantidad;i++){
        	cuartel.agregarPersonal(fabrica.crearHeroe());
        	cuartel.agregarVehiculo(fabrica.crearVehiculo());
        	cuartel.agregarHerramienta(fabrica.crearHerramienta());
        	}
        		return cuartel;
        	}
        	
        	return crearHeroe(fabrica);
        }
        
        static ICuartel crearHeroe(IFabricaDeHeroes fabrica)
        {
        	ICuartel cuartel = fabrica.crearCuartel();
        	
        	cuartel.agregarPersonal(fabrica.crearHeroe());
        	cuartel.agregarVehiculo(fabrica.crearVehiculo());
        	cuartel.agregarHerramienta(fabrica.crearHerramienta());
        	
        	return cuartel;
        }
        
        
        static void TestFabricas()
        {
        	FabricaDeBomberos bomberos = new FabricaDeBomberos();
        	FabricaDePolicias policias = new FabricaDePolicias();
        	FabricaDeElectricistas electricistas = new FabricaDeElectricistas();
        	FabricaDeMedicos medicos = new FabricaDeMedicos();
        	FabricaDeMecanicos mecanicos = new FabricaDeMecanicos();
        	
        	ICuartel comisaria = crearHeroe(policias,4);
        	ICuartel cuartelDeBomberos = crearHeroe(bomberos,4);
        	ICuartel centralElectrica = crearHeroe(electricistas,4);
        	ICuartel hospital = crearHeroe(medicos,4);
        	ICuartel tallerMecanico = crearHeroe(mecanicos,4);
        	
        	Manejador policia = (Manejador)comisaria.getPersonal();
        	Manejador bombero = (Manejador)cuartelDeBomberos.getPersonal();
        	Manejador electricista = (Manejador)centralElectrica.getPersonal();
        	Manejador medico = (Manejador)hospital.getPersonal();
        	Manejador mecanico = (Manejador)tallerMecanico.getPersonal();
        	
        	Random random = new Random();
        	Calle calle = new Calle(100,6,20);
        	directorDeSector director = new directorDeSector();
        	Plaza plaza = new Plaza(1000,calle,6,6,director);
        	policia.patrullarCalles(plaza);
        	bombero.apagarIncendio(plaza);
        	IInfartable infartable=new Transeunte(0.5,0.6,0.7,random);
        	medico.atenderInfarto(infartable);
        	electricista.revisar(plaza);
        	mecanico.remolcarAuto(policia.getVehiculo());
        	mecanico.arreglarMotor(policia.getVehiculo());
        	
        	
        	//Los devuelvo
        	comisaria.agregarHerramienta(policia.getHerramienta());
        	comisaria.agregarVehiculo(policia.getVehiculo());
        	comisaria.agregarPersonal(policia);
        	
        	cuartelDeBomberos.agregarHerramienta(bombero.getHerramienta());
        	cuartelDeBomberos.agregarVehiculo(bombero.getVehiculo());
        	cuartelDeBomberos.agregarPersonal(bombero);
        	
        	centralElectrica.agregarHerramienta(electricista.getHerramienta());
        	centralElectrica.agregarVehiculo(electricista.getVehiculo());
        	centralElectrica.agregarPersonal(electricista);
			
        	hospital.agregarHerramienta(electricista.getHerramienta());
        	hospital.agregarVehiculo(electricista.getVehiculo());
        	hospital.agregarPersonal(electricista);
        		
        	tallerMecanico.agregarHerramienta(mecanico.getHerramienta());
        	tallerMecanico.agregarVehiculo(mecanico.getVehiculo());
        	tallerMecanico.agregarPersonal(mecanico);
        	
        	
        	cuartelDeBomberos.getPersonal();
        	cuartelDeBomberos.getPersonal();
        	cuartelDeBomberos.getPersonal();
        	cuartelDeBomberos.getPersonal();
        	
        	
        	Comisaria cm = Comisaria.getInstanciaComisaria();
        	
        	cm.getPersonal();
        	cm.getPersonal();
        	IResponsable b3 = cm.getPersonal();
        	IResponsable b4 = cm.getPersonal();
        	cm.devolverPersonal(b4);
        	((Base)comisaria).devolverPersonal(b3);
        	
        }
	}
}