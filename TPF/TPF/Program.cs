using System;
using System.IO;
using System.Collections.Generic;


namespace TPF
{
    class Program
    {
        static void Main(string[] args)
        {

            //crear un arbolBinario y pasarle el Conjunto de datos como atributo o campo, 
            //luego pasar ese conjunto al clasificador
            //el clasificador me devuelve subconjuntos y la pregunta
            //los cuales relaciono a los hijos del arbolbinario nI nD hasta llegar a las hojas,
            //las cuales las determina el clasificador.

            //hack main
            /*ver tabla
             
            ConjuntoDeDatos hTabla = new ConjuntoDeDatos(@"C:\Users\chato\Desktop\tablaFrutas.csv", ',');


            foreach (string s in hTabla.Encabezados)
            {
                Console.Write(s + "\t - ");
            }
            Console.WriteLine("\n");

            foreach (IList<string> list in hTabla.Filas)
            {
                foreach (string s in list)
                {
                    Console.Write(s + " - \t");
                }
                Console.WriteLine("\n");

            }
            */

            Sistema();

            Console.WriteLine("\n....");
            Console.ReadKey();
        }

        /////////UNDONE ////////////
        public static void Sistema()
        {
            ArbolBinarioDesicion arbolDesicion = new ArbolBinarioDesicion();
            string ruta = @"C:\Users\chato\Desktop\tablaFrutas.csv";
            //string ruta = @"C:\Users\chato\Desktop\tablaPersonas.csv";
            bool salir = false;

            do
            {
                try
                {
                    Marco();
                    Console.WriteLine("¿A qué módulo desea ingresar?");
                    Console.Write("\n1) ADMINISTRACION");
                    Console.Write("\n2) CONSULTAS");
                    Console.Write("\n3) SALIR\n\n");

                    Relleno();

                    int eleccion = int.Parse(Console.ReadLine());

                    Relleno();

                    switch (eleccion)
                    {
                        case 1:
                            administracion(arbolDesicion,ruta);
                            break;
                        case 2:
                            consultas(arbolDesicion);
                            break;
                        case 3:
                            salir = true;
                            break;
                        default:
                            throw new Exception(eleccion + ": no es una opcion valida.\n Elija otra opcion");
                    }
                }

                catch (Exception e) { Console.WriteLine(e.Message); }

            } while (salir != true);

        }
        //MODULOS
        //HACK <----- modulo administracion
        public static void administracion(ArbolBinarioDesicion arbol,string ruta) {
            bool volver = false;
            do {
                try
                {
                    Marco();
                    Console.WriteLine("a) Construir un árbol de decisión a partir de un archivo con formato csv con los conjuntos de datos de entrenamiento.");
                    Console.WriteLine("b) Probar el árbol de decisión del sistema a partir de conjuntos de datos almacenados en un archivo con formato csv.");
                    Console.WriteLine("c) Volver");
                    Relleno();
                    string seleccion = "";
                    seleccion = Console.ReadLine().ToLower();

                    switch (seleccion)
                    {
                        case "a":
                            
                            
                            crearArbolDesicion(arbol,ruta);
                            
                            Console.WriteLine("arbol de desicion creado");
                            Console.WriteLine("presione una tecla para continuar");
                            Console.ReadKey();

                            break;
                        case "b":
                            mostrarArbol(arbol);
                            break;
                        case "c":
                            volver = true;
                            break;
                        default:
                            throw new Exception(seleccion + ": no es una opcion valida. Elija otra opcion.");
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }

            } while (volver != true);


        }
        //HACK <----- modulo consultas
        public static void consultas(ArbolBinarioDesicion arbol) {

            bool volver = false;

            do
            {
                try
                {
                    Marco();
                    Console.WriteLine("a) Imprimir predicciones");
                    Console.WriteLine("b) Dado un conjunto de características imprimir las preguntas y respuestas calculadas hasta llegar a una predicción.");
                    Console.WriteLine("c) Dada una profundidad imprimir las preguntas o predicciones ubicadas a dicha profundidad.");
                    Console.WriteLine("d) Volver");
                    Relleno();
                    string seleccion = "";
                    seleccion = Console.ReadLine().ToLower();

                    switch (seleccion)
                    {
                        case "a":
                             imprimirPredicciones(arbol);
                            break;
                        case "b":
                             preguntasYRespuestas(arbol);
                            break;
                        case "c":
                            Console.WriteLine("a implementar");
                            // ();
                            break;
                        case "d":
                            volver = true;
                            break;
                        default:
                            throw new Exception(seleccion + ": no es una opcion valida. Elija otra opcion.");
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }

            } while (volver != true);

        }

        private static void mostrarArbol(ArbolBinarioDesicion arbol){
            arbol.preorden();
        }

        private static void crearArbolDesicion(ArbolBinarioDesicion arbol,string ruta) {
            ConjuntoDeDatos CD = new ConjuntoDeDatos(ruta, ',');
            ArbolBinarioDesicion ABD = arbol;
            ABD.getRaiz().setConjuntoDeDatos(CD);

            crearArbol(ABD);

        }
        
        private static void crearArbol(ArbolBinarioDesicion ABD)
        {
            ConjuntoDeDatos CD = ABD.getConjuntoDeDatos();
            Clasificador Clasi = new Clasificador(CD);
            ABD.getRaiz().setPregunta(Clasi.obtenerPregunta());

            if (!Clasi.crearHoja())
            {
                ABD.agregarHijoIzquierdo(new ArbolBinarioDesicion());
                ABD.getHijoIzquierdo().setConjuntoDeDatos(Clasi.obtenerDatosIzquierdo());
                crearArbol(ABD.getHijoIzquierdo());

                ABD.agregarHijoDerecho(new ArbolBinarioDesicion());
                ABD.getHijoDerecho().setConjuntoDeDatos(Clasi.obtenerDatosDerecho());
                crearArbol(ABD.getHijoDerecho());
            }

        }
        private static void imprimirPredicciones(ArbolBinarioDesicion arbol)
        {
            arbol.mostrarHojas();
        }

        private static void preguntasYRespuestas(ArbolBinarioDesicion arbol)
        {
            arbol.desiciones();
        }

        public static void Marco()
        {
            string nombre = "SISTEMA DE PREDICCIÓN";

            string texto2 = "*****";
            string e = "     ";
            string espacioTotal = e + e + e + e + e + e + e + e + e + e + e + e + e + e;
            string tF = texto2 + espacioTotal + texto2;
            int indiceTexto = nombre.Length / 2;
            int indiceM = (tF.Length / 2) - indiceTexto;

            tF = tF.Remove(indiceM, nombre.Length);
            tF = tF.Insert(indiceM, nombre);
            Relleno();
            Console.WriteLine(texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2);
            Console.WriteLine(tF);
            Console.WriteLine(texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2 + texto2);
            Console.WriteLine();
            Relleno();

        }

        public static void Relleno()
        {

            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");

        }




    }
}
